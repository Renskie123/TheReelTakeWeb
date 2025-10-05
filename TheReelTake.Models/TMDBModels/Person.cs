using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReelTake.Models.TMDBModels
{
    public class Person : Cast
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("biography")]
        public string Biography { get; set; }
        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }
        [JsonProperty("place_of_birth")]
        public string PlaceOfBirth { get; set; }
        [JsonProperty("also_known_as")]
        public List<string> AlsoKnownAs { get; set; }
        [JsonProperty("gender")]
        public int Gender { get; set; }

    }
}
