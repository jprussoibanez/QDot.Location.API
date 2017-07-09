using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QDot.Location.API.Infrastructure.ActionResults
{
    /// <summary>
    /// Represents internal server error for status code 500
    /// </summary>
    public class InternalServerErrorObjectResult : ObjectResult
    {
        /// <summary>
        /// Constructor to set error object 
        /// </summary>
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
