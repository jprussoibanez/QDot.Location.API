using QDot.Location.API.Client.BaseAPI.Requests;
using System.Threading.Tasks;

namespace QDot.Location.API.Client.BaseAPI
{
    public interface IAPIClient
    {
        Task<T> ExecuteAsync<T>(IAPIRequest<T> request) where T : class;
    }
}
