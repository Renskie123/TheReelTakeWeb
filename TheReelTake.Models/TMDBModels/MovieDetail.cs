using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReelTake.Models.TMDBModels
{
    public class MovieDetail : Movie
    {
        [JsonProperty("runtime")]
        public int? Runtime { get; set; }

        [JsonProperty("budget")]
        public long Budget { get; set; }

        [JsonProperty("revenue")]
        public long Revenue { get; set; }
        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }
        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }
        [JsonProperty("production_companies")]
        public List<ProductionCompany> ProductionCompanies { get; set; }
        [JsonProperty("production_countries")]
        public List<ProductionCountry> ProductionCountries { get; set; }
        [JsonProperty("spoken_languages")]
        public List<SpokenLanguage> SpokenLanguages { get; set; }
        [JsonProperty("credits")]
        public Credits Credits { get; set; }
    }
}
