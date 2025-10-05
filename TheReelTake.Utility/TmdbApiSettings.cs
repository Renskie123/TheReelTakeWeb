using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReelTake.Utility
{
    public class TmdbApiSettings
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public static string ImageBaseUrl { get; set; }
    }
}
