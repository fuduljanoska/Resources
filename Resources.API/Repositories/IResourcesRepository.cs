using Resources.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.API.Repositories
{
    public interface IResourcesRepository
    {
        public IEnumerable<Resource> GetAllResources();
        public ValueTask<Resource> GetResourceAsync(int id);
    }
}
