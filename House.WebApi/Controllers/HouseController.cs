using House.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace House.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _houseService.CalculatePricesPerMeterPerCounties();
            return Ok(list);
        }
    }
}
