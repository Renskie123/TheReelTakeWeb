using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheReelTake.Models.TMDBModels;

namespace TheReelTake.DataAccess.Repository.IMDBRepository.IIMDBRepository
{
    public interface ITmdbService
    {
        Task<MovieResponse> GetPopularMoviesAsync(int page = 1);
        Task<MovieResponse> GetTopRatedMoviesAsync(int page = 1);
        Task<MovieResponse> GetUpcomingMoviesAsync(int page = 1);
        Task<MovieDetail> GetMovieDetailsAsync(int movieId);
        Task<Person> GetActorDetailsAsync(int actorId);
        Task<PersonCreditsResponse> GetMoviesByActorAsync(int movieId);
        Task<List<MovieDetail>> GetMovieDetailsByActorAsync(int actorId);
    }
}
