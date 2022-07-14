using House.DAL;
using House.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace House.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly HouseContext _context;

        public HouseController(HouseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var houses = _context.Houses.ToList();
            return Ok(houses);
        }
    }
}
