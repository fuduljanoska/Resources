using Resources.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.API.Repositories
{
    public class ResourcesRepository : IResourcesRepository
    {
        public Task<IEnumerable<Resource>> GetAllResourcesAsync()
        {
            return Task.FromResult((IEnumerable<Resource>)new List<Resource>()
            {
                new Resource() { Id = 1, Name = "Resource 1", Quantity = 10},
                new Resource() { Id = 2, Name = "Resource 2", Quantity = 5},
                new Resource() { Id = 3, Name = "Resource 3", Quantity = 10},
            });
        }

        public Task<Resource> GetResourceAsync(int id)
        {
            return Task.FromResult(new Resource() { Id = 1, Name = "Resource 1", Quantity = 10 });
        }
    }
}
