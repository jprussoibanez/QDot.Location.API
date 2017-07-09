using System.Collections.Generic;

namespace QDot.Location.API.Client.BaseAPI.Requests
{
    public interface IAPIRequest<T> where T : class
    {
        /// <summary>
        /// Get the api relative url. eg. /channel/v2/123
        /// </summary>
        string GetUrl();

        /// <summary>
        /// Get the request body stream
        /// </summary>
        byte[] GetRequestStream();

        /// <summary>
        /// Get the api http method.
        /// </summary>

        HttpMethod GetHttpMethod();

        /// <summary>
        /// Get the parameters in the request url.
        /// </summary>
        IDictionary<string, string> GetUrlParameters();

        /// <summary>
        /// Get the parameters in the request headers.
        /// </summary>
        IDictionary<string, string> GetRequestHeaders();

        /// <summary>
        /// Validate the request parameters before send out the request.
        /// </summary>
        void Validate();
    }
}