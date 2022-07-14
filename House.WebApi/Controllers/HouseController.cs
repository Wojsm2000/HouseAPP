using House.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace House.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly List<CountyPricePerMeterViewModel> _countyPricePerMeterViewModels = new List<CountyPricePerMeterViewModel>()
        {
            new CountyPricePerMeterViewModel() { County = "łódzkie", PricePerMeter = 7800 },
            new CountyPricePerMeterViewModel() { County = "świętokrzyskie", PricePerMeter = 9000 },
            new CountyPricePerMeterViewModel() { County = "mazowieckie", PricePerMeter = 3000 },
            new CountyPricePerMeterViewModel() { County = "pomorskie", PricePerMeter = 5000 },
            new CountyPricePerMeterViewModel() { County = "małopolskie", PricePerMeter = 3200 },
            new CountyPricePerMeterViewModel() { County = "podkarpackie", PricePerMeter = 4000 }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_countyPricePerMeterViewModels);
        }
    }
}
