using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewMarkAPI.Services;

namespace NewMarkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            var properties = await _propertyService.GetPropertiesFromBlobAsync();
            return Ok(properties);
        }

    }
}
