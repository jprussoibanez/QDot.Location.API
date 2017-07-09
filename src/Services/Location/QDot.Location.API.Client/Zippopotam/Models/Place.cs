using Newtonsoft.Json;

namespace QDot.Location.API.Client.Zippopotam.Models
{
    /// <summary>
    /// Place description from zippopotam
    /// </summary>
    /// <example>
    /// Example Url: http://api.zippopotam.us/us/90210
    /// Example Result: {"place name": "Beverly Hills", "longitude": "-118.3995", "state": "California", "state abbreviation": "CA", "latitude": "34.0619"}
    /// </example>
    public class Place
    {
        [JsonProperty(PropertyName = "place name")]
        public string PlaceName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string State { get; set; }
        [JsonProperty(PropertyName = "state abbreviation")]
        public string StateAbbreviation { get; set; }
    }
}
