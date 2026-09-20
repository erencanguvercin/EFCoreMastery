using EFCoreMastery.Services.DTOs.Order;

namespace EFCoreMastery.Services.Interfaces.Order
{
    public interface IGetFilteredOrderReportService
    {
        Task<List<FilteredOrderReportDto>> GetFilteredOrderReportAsync(DateTime startDate,DateTime endDate);
    }
}
