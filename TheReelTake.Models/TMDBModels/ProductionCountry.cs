using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReelTake.Models.TMDBModels
{
    public class ProductionCountry
    {
        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
