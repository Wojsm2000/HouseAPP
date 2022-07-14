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
            throw new NotImplementedException();
        }
    }
}
