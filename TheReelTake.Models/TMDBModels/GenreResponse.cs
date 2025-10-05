using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReelTake.Models.TMDBModels
{
    public class GenreResponse
    {
        [JsonProperty("genres")]
        List<Genre> genres { get; set; }
    }
}
