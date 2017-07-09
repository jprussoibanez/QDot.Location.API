using System.Collections.Generic;
using System.Threading.Tasks;
using QDot.Location.Core.Models;

namespace QDot.Location.Core.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<Models.Location>> GetLocationsAsync(List<string> zipCodes);
    }
}
