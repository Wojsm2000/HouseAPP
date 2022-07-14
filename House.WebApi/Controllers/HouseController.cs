using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace House.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Api dziala");
        }
    }
}
