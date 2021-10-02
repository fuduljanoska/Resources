using Resources.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.API.Services
{
    public interface IResourcesService
    {
        Task<IEnumerable<Resource>> GetAllResourcesAsync();
    }
}
