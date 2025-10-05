using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReelTake.Models.TMDBModels.ViewModel
{
    public class ActorMovieViewModel
    {
        public Person Actor { get; set; }
        public List<MovieDetail> Movies { get; set; }
    }
}
