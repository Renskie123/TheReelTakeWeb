using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReelTake.Models.TMDBModels.ViewModel
{
    public class HomeViewModel
    {
        public List<Movie> PopularMovies { get; set; }
        public List<Movie> TopRatedMovies { get; set; }
        public List<Movie> UpcomingMovies { get; set; }
    }
}
