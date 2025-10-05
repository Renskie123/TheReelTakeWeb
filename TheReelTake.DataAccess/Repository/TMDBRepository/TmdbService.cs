using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TheReelTake.DataAccess.Repository.IMDBRepository.IIMDBRepository;
using TheReelTake.Models.TMDBModels;
using TheReelTake.Utility;

namespace TheReelTake.DataAccess.Repository.TMDBRepository
{
    public class TmdbService : ITmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly TmdbApiSettings _settings;
        private readonly ILogger<TmdbService> _logger;

        public TmdbService(HttpClient httpClient, IOptions<TmdbApiSettings> settings, ILogger<TmdbService> logger)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
            _logger = logger;

            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<MovieResponse> GetPopularMoviesAsync(int page = 1)
        {
            return await GetAsync<MovieResponse>($"movie/popular?api_key={_settings.ApiKey}&page={page}");
        }

        public async Task<MovieResponse> GetTopRatedMoviesAsync(int page = 1)
        {
            return await GetAsync<MovieResponse>($"movie/top_rated?api_key={_settings.ApiKey}&page={page}");
        }

        public async Task<MovieResponse> GetUpcomingMoviesAsync(int page = 1)
        {
            return await GetAsync<MovieResponse>($"movie/upcoming?api_key={_settings.ApiKey}&page={page}");
        }

        public async Task<MovieDetail> GetMovieDetailsAsync(int movieId)
        {
            return await GetAsync<MovieDetail>($"movie/{movieId}?api_key={_settings.ApiKey}&append_to_response=credits");
        }

        public async Task<Person> GetActorDetailsAsync(int actorId)
        {
            return await GetAsync<Person>($"person/{actorId}?api_key={_settings.ApiKey}&append_to_response=credits");
        }

        public async Task<PersonCreditsResponse> GetMoviesByActorAsync(int actorId)
        {
            return await GetAsync<PersonCreditsResponse>($"person/{actorId}/combined_credits?api_key={_settings.ApiKey}&append_to_response=credits");
        }

        public async Task<List<MovieDetail>> GetMovieDetailsByActorAsync(int actorId)
        {
            var credits = await GetMoviesByActorAsync(actorId);
            var movieDetails = new List<MovieDetail>();

            // Get details for each movie (you might want to limit this)
            foreach (var castMovie in credits.Crew.Take(10)) // Limit to avoid too many API calls
            {
                var movieDetail = await GetAsync<MovieDetail>($"movie/{castMovie.CreditId}?api_key={_settings.ApiKey}");
                movieDetails.Add(movieDetail);
            }

            return movieDetails;
        }

        private async Task<T> GetAsync<T>(string endpoint) where T : new()
        {
            try
            {
                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error calling TMDB API: {Endpoint}", endpoint);
                throw new TmdbApiException("Error calling TMDB API", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error calling TMDB API: {Endpoint}", endpoint);
                return new T();
            }
        }

        public class TmdbApiException : Exception
        {
            public TmdbApiException(string message, Exception innerException)
                : base(message, innerException) { }
        }
    }
}
