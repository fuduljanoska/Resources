using Resources.API.Models;
using System.Collections.Generic;

namespace Resources.API.Services
{
    public interface IResourcesService
    {
        IEnumerable<Resource> GetAllResources();
    }
}
