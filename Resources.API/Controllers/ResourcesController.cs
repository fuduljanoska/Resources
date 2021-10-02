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
        public async Task<ActionResult<IEnumerable<Resource>>> GetAllResourcesAsync()
        {
            try
            {
                var resources = await _resourcesService.GetAllResourcesAsync();

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
