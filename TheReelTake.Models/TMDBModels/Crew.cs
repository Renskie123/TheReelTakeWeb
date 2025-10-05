using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReelTake.Models.TMDBModels
{
    public class Crew : Cast
    {
        [JsonProperty("known_for_department")]
        public string Job { get; set; }
    }
}
