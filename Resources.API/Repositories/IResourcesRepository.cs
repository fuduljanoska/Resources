using Resources.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resources.API.Repositories
{
    public interface IResourcesRepository
    {
        public Task<IEnumerable<Resource>> GetAllResourcesAsync();
        public Task<Resource> GetResourceAsync(int id);
    }
}
