using Microsoft.AspNetCore.Mvc;
using Resources.API.Models;
using Resources.API.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Resources.API.Controllers
{
    [Route("[controller]")]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourcesService _resourcesService;

        public ResourcesController(IResourcesService resourcesService)
        {
            _resourcesService = resourcesService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<IEnumerable<Resource>> GetAllResources()
        {
            try
            {
                var resources = _resourcesService.GetAllResources();

                return Ok(resources);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message,
                    null,
                    (int)HttpStatusCode.InternalServerError,
                    "Exception was thrown during resources fetch.");
            }
        }
    }
}
