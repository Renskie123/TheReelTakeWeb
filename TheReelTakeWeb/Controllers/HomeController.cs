using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net.Http.Headers;
using TheReelTake.DataAccess.Repository.IMDBRepository.IIMDBRepository;
using TheReelTake.DataAccess.Repository.TMDBRepository;
using TheReelTake.Models;
using TheReelTake.Models.TMDBModels;
using TheReelTake.Models.TMDBModels.ViewModel;
using TheReelTake.Utility;
using TheReelTakeWeb.Models;

namespace TheReelTakeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITmdbService _tmdbService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITmdbService tmdbService, ILogger<HomeController> logger)
        {
            _tmdbService = tmdbService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            try
            {
                var pupularMovies = await _tmdbService.GetPopularMoviesAsync(page);
                var topRatedMovies = await _tmdbService.GetTopRatedMoviesAsync(page);
                var upcomingMovies = await _tmdbService.GetUpcomingMoviesAsync(page);

                var homeVM = new HomeViewModel
                {
                    PopularMovies = pupularMovies.Results,
                    TopRatedMovies = topRatedMovies.Results,
                    UpcomingMovies = upcomingMovies.Results
                };

                //ViewBag.CurrentPage = page;
                //ViewBag.PopularTotalPages = pupularMovies.TotalPages;
                //ViewBag.TopRatedTotalPages = topRatedMovies.TotalPages;

                return View(homeVM);
            }
            // If TmdbApiException does not exist, replace with Exception or a more specific exception type.
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching popular movies");
                return View("Error", new ErrorViewModel { Message = "Error fetching movies from TMDB" });
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var movieDetails = await _tmdbService.GetMovieDetailsAsync(id);

                if(movieDetails == null)
                {
                    return NotFound();
                }

                //ViewBag.CurrentPage = page;
                //ViewBag.PopularTotalPages = pupularMovies.TotalPages;
                //ViewBag.TopRatedTotalPages = topRatedMovies.TotalPages;

                return View(movieDetails);
            }
            // If TmdbApiException does not exist, replace with Exception or a more specific exception type.
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching movie details");
                return View("Error", new ErrorViewModel { Message = "Error fetching movies details from TMDB" });
            }
        }

        public async Task<IActionResult> ActorDetails(int id)
        {
            try
            {
                var castDetails = await _tmdbService.GetActorDetailsAsync(id);
                var castMovies = await _tmdbService.GetMoviesByActorAsync(id);


                if (castDetails == null || castMovies == null)
                {
                    return NotFound();
                }

                var actorVM = new ActorMovieViewModel
                {
                    Actor = castDetails,
                    Movies = castMovies.Cast
                        .Where(c => !string.IsNullOrWhiteSpace(c.Title)) // Filter out movies without titles
                        .GroupBy(c => c.Title) // Group by title to remove duplicates
                        .Select(g => g.First()) // Take the first movie from each title group
                        .Select(c => new MovieDetail
                        {
                            Id = c.Id,
                            Title = c.Title,
                            VoteAverage = c.VoteAverage,
                            ReleaseDate = c.ReleaseDate,
                            PosterPath = c.PosterPath,
                        }).ToList()
                };

                //ViewBag.CurrentPage = page;
                //ViewBag.PopularTotalPages = pupularMovies.TotalPages;
                //ViewBag.TopRatedTotalPages = topRatedMovies.TotalPages;

                return View(actorVM);
            }
            // If TmdbApiException does not exist, replace with Exception or a more specific exception type.
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching cast detail");
                return View("Error", new ErrorViewModel { Message = "Error fetching cast detail from TMDB" });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
