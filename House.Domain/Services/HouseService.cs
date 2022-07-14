using House.Domain.ViewModels;

namespace House.Domain.Services
{
    public class HouseService : IHouseService
    {
        private readonly HouseContext _houseContext;

        public HouseService(HouseContext houseContext)
        {
            _houseContext = houseContext;
        }

        public IEnumerable<CountyPricePerMeterViewModel> CalculatePricesPerMeterPerCounties()
        {
            //get data from DB:
            var houses = _houseContext.Houses.ToList();

            //create list to return
            var viewModels = new List<CountyPricePerMeterViewModel>();

            //get distinct list of counties
            var counties = houses.Select(p => p.County).Distinct();

            //for each county
            foreach(var county in counties)
            {
                var viewModel = new CountyPricePerMeterViewModel();

                //get houses for each county
                var housesInCounty = houses.Where(p => p.County == county);

                //for each house in county, calculate the price per meter and put into sum
                var sum = 0m;
                foreach(var houseInCounty in housesInCounty)
                {
                    var pricePerMeter = houseInCounty.Price / (decimal)houseInCounty.Area;
                    sum = sum + pricePerMeter;
                }

                viewModel.County = county;
                viewModel.AveragePricePerMeter = sum / housesInCounty.Count();

                viewModels.Add(viewModel);
            }

            return viewModels;
        }
    }
}
