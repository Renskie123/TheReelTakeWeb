using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReelTake.Models.TMDBModels
{
    public class PersonCreditsResponse
    {
        [JsonProperty("cast")]
        public List<CastMovie> Cast { get; set; }

        [JsonProperty("crew")]
        public List<CrewMovie> Crew { get; set; }
    }
}
