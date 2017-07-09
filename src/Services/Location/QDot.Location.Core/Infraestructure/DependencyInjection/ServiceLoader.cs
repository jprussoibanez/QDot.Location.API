using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QDot.API.Configuration;
using QDot.Location.API.Client.BaseAPI;
using QDot.Location.API.Client.Zippopotam;
using QDot.Location.Core.Services;
using QDot.Location.Core.Services.Interfaces;

namespace QDot.Location.Core.Infraestructure.DependencyInjection
{
    public static class ServiceLoader
    {
        public static void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<ILocationService, LocationService>();
            services.AddSingleton<IAPIClient, ZippopotamClient>();

            services.Configure<ApiClientSettings>(configuration.GetSection("apiClientSettings"));
        }
    }
}
