using Newtonsoft.Json;
using QDot.Location.API.Client.Zippopotam.Models;
using System.Collections.Generic;

namespace QDot.Location.API.Client.Zippopotam.Responses
{
    /// <summary>
    /// Zip code information from zippopotam
    /// </summary>
    /// <example>
    /// Example: http://api.zippopotam.us/us/90210
    /// Example: {"post code": "90212", "country": "United States", "country abbreviation": "US", "places": [{"place name": "Beverly Hills", "longitude": "-118.3995", "state": "California", "state abbreviation": "CA", "latitude": "34.0619"}]}
    /// </example>
    public class GetPlacesByZipCodeResponse
    {
        [JsonProperty(PropertyName = "post code")]
        public string PostCode { get; set; }
        public string Country { get; set; }
        [JsonProperty(PropertyName = "country abbreviation")]
        public string CountryAbbrevation { get; set; }
        public List<Place> Places { get; set; }
        
    }
}
