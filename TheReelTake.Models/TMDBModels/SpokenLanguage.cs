using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReelTake.Models.TMDBModels
{
    public class SpokenLanguage
    {
        [JsonProperty("english_name")]
        public string EnglishName { get; set; }
        [JsonProperty("iso_639_1")]
        public string Iso639_1 { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
