using House.Domain.ViewModels;

namespace House.Domain.Services
{
    public interface IHouseService
    {
        IEnumerable<CountyPricePerMeterViewModel> CalculatePricesPerMeterPerCounties();
    }
}
