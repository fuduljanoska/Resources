using Resources.API.DataAccess;
using Resources.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resources.API.Repositories
{
    public class ResourcesRepository : IResourcesRepository
    {
        private readonly ResourcesDbContext _resourcesDbContext;

        public ResourcesRepository(ResourcesDbContext resourcesDbContext)
        {
            _resourcesDbContext = resourcesDbContext;
        }

        public IEnumerable<Resource> GetAllResources()
        {
            return _resourcesDbContext.ResourcesDbSet.AsEnumerable();
        }

        public ValueTask<Resource> GetResourceAsync(int id)
        {
            return _resourcesDbContext.ResourcesDbSet.FindAsync(id);
        }
    }
}
