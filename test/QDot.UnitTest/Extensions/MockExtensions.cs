using Moq;
using QDot.Location.API.Client.BaseAPI;
using QDot.Location.API.Client.Zippopotam.Requests;
using QDot.Location.API.Client.Zippopotam.Responses;

namespace QDot.UnitTest.Extensions
{
    public static class MockExtensions
    {
        public static void SetupAPICall(this Mock<IAPIClient> mockAPIClient, GetPlacesByZipCodeResponse expectedResult)
        {
            var expectedUrl = string.Format("us/{0}", expectedResult.PostCode);
            mockAPIClient
                .Setup(m => m.ExecuteAsync(It.Is<GetPlacesByZipCodeRequest>(r => r.GetUrl().Equals(expectedUrl))))
                .ReturnsAsync(expectedResult);
        }
    }
}
