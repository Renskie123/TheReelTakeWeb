using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReelTake.Models.TMDBModels
{
    public class ProductionCompany
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("logo_path")]
        public string LogoPath { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("origin_country")]
        public string OriginCountry { get; set; }
    }
}
