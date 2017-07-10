using FluentAssertions;
using Moq;
using QDot.Location.API.Client.BaseAPI;
using QDot.Location.API.Client.Infraestructure.Exceptions;
using QDot.Location.API.Client.Zippopotam.Requests;
using QDot.Location.API.Client.Zippopotam.Responses;
using QDot.Location.Core.Infraestructure.Exceptions;
using QDot.Location.Core.Models;
using QDot.Location.Core.Services;
using QDot.UnitTest.Extensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace QDot.UnitTest.Services
{
    public class LocationServiceTest
    {
        [Fact(DisplayName = "Get location for one zip code in new york")]
        public async void GetLocationForNewYork()
        {
            //Arrange
            var mockAPIClient = new Mock<IAPIClient>();
            var locationService = new LocationService(mockAPIClient.Object);
            mockAPIClient.SetupAPICall(_GetNewYork());

            //Act
            var locations = await locationService.GetLocationsAsync(new List<string> { _GetNewYork().PostCode });

            //Assert
            locations.Should().BeEquivalentTo(_GetNewYorkLocations());
        }

        [Fact(DisplayName = "Get locations for two zip codes on same state (california)")]
        public async void GetLocationsForCalifornia()
        {
            //Arrange
            var mockAPIClient = new Mock<IAPIClient>();
            var locationService = new LocationService(mockAPIClient.Object);
            mockAPIClient.SetupAPICall(_GetSanFrancisco());
            mockAPIClient.SetupAPICall(_GetBeverlyHills());

            //Act
            var locations = await locationService.GetLocationsAsync(new List<string> { _GetBeverlyHills().PostCode, _GetSanFrancisco().PostCode });

            //Assert
            locations.Should().BeEquivalentTo(_GetCaliforniaLocations());
        }

        [Fact(DisplayName = "Get locations for two different states (california and new york)")]
        public async void GetLocationsForCaliforniaAndNewYork()
        {
            //Arrange
            var mockAPIClient = new Mock<IAPIClient>();
            var locationService = new LocationService(mockAPIClient.Object);
            mockAPIClient.SetupAPICall(_GetSanFrancisco());
            mockAPIClient.SetupAPICall(_GetBeverlyHills());
            mockAPIClient.SetupAPICall(_GetNewYork());
            
            //Act
            var locations = await locationService.GetLocationsAsync(new List<string> { _GetBeverlyHills().PostCode, _GetSanFrancisco().PostCode, _GetNewYork().PostCode });

            //Assert
            locations.Should().BeEquivalentTo(new List<Location.Core.Models.Location> {
                _GetCaliforniaLocations(),
                _GetNewYorkLocations()
            });
        }

        [Fact(DisplayName = "Throw service parameter exception for argument client exception")]
        public void ThrowServiceParameterExceptionForArgumentClientException()
        {
            //Arrange
            var mockAPIClient = new Mock<IAPIClient>();
            var locationService = new LocationService(mockAPIClient.Object);
            mockAPIClient
                .Setup(m => m.ExecuteAsync(It.IsAny<GetPlacesByZipCodeRequest>()))
                .Throws(new APIClientParameterException());

            //Act
            Func<Task> act = async () => await locationService.GetLocationsAsync(new List<string> {"bad zip code"});

            //Assert
            act.ShouldThrow<ServiceParameterException>();
        }

        [Fact(DisplayName = "Throw service parameter exception for null zip codes")]
        public void ThrowServiceParameterExceptionForNullZipCodes()
        {
            //Arrange
            var mockAPIClient = new Mock<IAPIClient>();
            var locationService = new LocationService(mockAPIClient.Object);
            
            //Act
            Func<Task> act = async () => await locationService.GetLocationsAsync(null);

            //Assert
            act.ShouldThrow<ServiceParameterException>();
        }
        
        #region Arrange Helpers

        private Location.Core.Models.Location _GetCaliforniaLocations()
        {
            return new Location.Core.Models.Location
            {
                State = "California",
                Places = new List<Place>
                {
                    new Place()
                    {
                        Name = "Beverly Hills",
                        Latitude = 34.0901,
                        Longitude = -118.4065,
                        ZipCode = "90210"
                    },
                    new Place()
                    {
                        Name = "San Francisco",
                        Latitude = 37.745,
                        Longitude = -122.4383,
                        ZipCode = "94131"
                    }
                }
            };
        }

        private Location.Core.Models.Location _GetNewYorkLocations()
        {
            return new Location.Core.Models.Location
            {
                State = "New York",
                Places = new List<Place>
                {
                    new Place()
                    {
                        Name = "New York City",
                        Latitude = 40.7069,
                        Longitude = -73.6731,
                        ZipCode = "10000"
                    }
                }
            };
        }
        private GetPlacesByZipCodeResponse _GetBeverlyHills()
        {
            return new GetPlacesByZipCodeResponse
            {
                PostCode = "90210",
                Country = "United States",
                CountryAbbrevation = "US",
                Places = new List<Location.API.Client.Zippopotam.Models.Place>()
                {
                    new Location.API.Client.Zippopotam.Models.Place
                    {
                        State = "California",
                        StateAbbreviation = "CA",
                        Latitude = 34.0901,
                        Longitude = -118.4065,
                        PlaceName = "Beverly Hills"
                    }
                }
            };
        }

        private GetPlacesByZipCodeResponse _GetSanFrancisco()
        {
            return new GetPlacesByZipCodeResponse
            {
                PostCode = "94131",
                Country = "United States",
                CountryAbbrevation = "US",
                Places = new List<Location.API.Client.Zippopotam.Models.Place>()
                {
                    new Location.API.Client.Zippopotam.Models.Place
                    {
                        State = "California",
                        StateAbbreviation = "CA",
                        Latitude = 37.745,
                        Longitude = -122.4383,
                        PlaceName = "San Francisco"
                    }
                }
            };
        }

        private GetPlacesByZipCodeResponse _GetNewYork()
        {
            return new GetPlacesByZipCodeResponse
            {
                PostCode = "10000",
                Country = "United States",
                CountryAbbrevation = "US",
                Places = new List<Location.API.Client.Zippopotam.Models.Place>()
                {
                    new Location.API.Client.Zippopotam.Models.Place
                    {
                        State = "New York",
                        StateAbbreviation = "NY",
                        Latitude = 40.7069,
                        Longitude = -73.6731,
                        PlaceName = "New York City"
                    }
                }
            };
        }
        #endregion
    }
}
