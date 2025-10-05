using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheReelTake.Utility;

namespace TheReelTake.Models.TMDBModels
{
    public class Cast
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("character")]
        public string Character { get; set; }
        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }
        public string FullProfilePath => !string.IsNullOrEmpty(ProfilePath)
        ? $"{TmdbApiSettings.ImageBaseUrl}w185{ProfilePath}"
        : "/images/no-profile.jpg";
    }
}
