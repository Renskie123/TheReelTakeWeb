using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheReelTake.Utility;

namespace TheReelTake.Models.TMDBModels
{
    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        public string FullPosterPath => !string.IsNullOrEmpty(PosterPath)
            ? $"{TmdbApiSettings.ImageBaseUrl}w500{PosterPath}"
            : "/images/no-poster.jpg";

        public string FullBackdropPath => !string.IsNullOrEmpty(BackdropPath)
            ? $"{TmdbApiSettings.ImageBaseUrl}w1280{BackdropPath}"
            : "/images/no-backdrop.jpg";
    }
}
