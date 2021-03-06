using Resources.API.Models;
using Resources.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.API.Services
{
    public class ResourcesService : IResourcesService
    {
        private readonly IResourcesRepository _resourcesRepository;

        public ResourcesService(IResourcesRepository resourcesRepository)
        {
            _resourcesRepository = resourcesRepository;
        }

        public IEnumerable<Resource> GetAllResources()
        {
            return _resourcesRepository.GetAllResources();
        }
    }
}
