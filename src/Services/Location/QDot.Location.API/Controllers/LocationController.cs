using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QDot.Location.Core.Services.Interfaces;

namespace QDot.Location.API.Controllers
{
    /// <summary>
    /// Controller to handle location operations 
    /// </summary>
    [Route("api/us/[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        /// <summary>
        /// Controller to inject location service
        /// </summary>
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Get locations for all provided zip codes. The location contains the places for the zip codes group by state. 
        /// </summary>
        /// <remarks>
        /// Note that the zip codes should be passed as query strings like GET api/us/location?zipCodes=10000&amp;zipCodes=90210&amp;zipCodes=94131 
        /// The US zip codes have a basic format of five digits. 
        /// </remarks>
        /// <param name="zipCodes">List of zip codes to search</param>
        /// <example></example>
        /// <returns>Returns the list of places on the zip codes grouped by state</returns> 
        /// <response code="200">Returns the location places grouped by state</response>
        /// <response code="400">If any zip code is empty or badly formatted</response>
        /// <response code="404">If any zip code is not found</response>
        [HttpGet()]
        public async Task<IEnumerable<Core.Models.Location>> Get(List<string> zipCodes)
        {
            return await _locationService.GetLocationsAsync(zipCodes); 
        }
    }
}
