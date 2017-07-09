using QDot.Location.API.Client.BaseAPI;
using QDot.Location.API.Client.BaseAPI.Requests;
using QDot.Location.API.Client.Validators;
using QDot.Location.API.Client.Zippopotam.Responses;
using System.Collections.Generic;

namespace QDot.Location.API.Client.Zippopotam.Requests
{
    public class GetPlacesByZipCodeRequest : IAPIRequest<GetPlacesByZipCodeResponse>
    {
        private readonly string _zipCode;

        public GetPlacesByZipCodeRequest(string zipCode)
        {
            _zipCode = zipCode;
        }

        public HttpMethod GetHttpMethod()
        {
            return HttpMethod.GET;
        }

        public IDictionary<string, string> GetRequestHeaders()
        {
            return new Dictionary<string, string>();
        }

        public byte[] GetRequestStream()
        {
            return null;
        }

        public string GetUrl()
        {
            return string.Format("us/{0}", _zipCode);
        }

        public IDictionary<string, string> GetUrlParameters()
        {
            return new Dictionary<string, string>();
        }

        public void Validate()
        {
            RequestValidator.RequiredField("zip code", _zipCode);
            RequestValidator.Match("zip code", _zipCode,  @"^\d{5}(?:[-\s]\d{4})?$");
        }
    }
}
