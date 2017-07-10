using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QDot.Location.API.Client.BaseAPI;
using QDot.Location.API.Client.Zippopotam.Requests;
using QDot.Location.Core.Models;
using QDot.Location.Core.Services.Interfaces;
using QDot.Location.API.Client.Infraestructure.Exceptions;
using QDot.Location.Core.Infraestructure.Exceptions;
using QDot.Location.Core.Infraestructure.Resources;
using System.Net;

namespace QDot.Location.Core.Services
{
    public class LocationService : ILocationService
    {
        #region Attributes

        private readonly IAPIClient _apiClient;

        #endregion

        #region Constructors

        public LocationService(IAPIClient apiClient)
        {
            _apiClient = apiClient;
        }

        #endregion

        #region Operations

        public async Task<IEnumerable<Models.Location>> GetLocationsAsync(IEnumerable<string> zipCodes)
        {
            var validatedZipCodes = _ValidateZipCodes(zipCodes);

            try
            {
                var locations = await Task.WhenAll(validatedZipCodes.Select(zipCode => _apiClient.ExecuteAsync(new GetPlacesByZipCodeRequest(zipCode))));

                return from location in locations
                       from places in location.Places
                       group new { places, location.PostCode } by places.State into resultsByState
                       select new Models.Location
                       {
                           State = resultsByState.Key,
                           Places = resultsByState.Select(g => new Place(g.places, g.PostCode)).ToList()
                       };

            }
            catch (WebException ex)
            {
                _HandleWebException(ex);
                throw;
            }
        }

        #endregion

        #region Helpers

        private IEnumerable<string> _ValidateZipCodes(IEnumerable<string> zipCodes)
        {
            if (zipCodes == null)
            {
                throw new ServiceParameterException(ErrorMessages.ZipCodesRequired);
            }

            var distinctZipCodes = zipCodes.Distinct();

            try
            {
                foreach (var zipCode in distinctZipCodes)
                {
                    var request = new GetPlacesByZipCodeRequest(zipCode);
                    request.Validate();
                }
            }
            catch (APIClientParameterException ex)
            {
                throw new ServiceParameterException(ex.Message, ex);
            }

            return distinctZipCodes;
        }

        private void _HandleWebException(WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
            {
                var resp = (HttpWebResponse)ex.Response;
                switch (resp.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new LocationNotFoundException(ErrorMessages.ZipCodesNotFound);

                        //TODO: Add more specific status code handling
                }
            }
        }

        #endregion
    }
}