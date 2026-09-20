using EFCoreMastery.Services.DTOs.Customer;

namespace EFCoreMastery.Services.Interfaces.Customer
{
    public interface IGetVIPCustomerReportService
    {
        Task<List<VIPCustomerReportDto>> GetVIPCustomerReportAsync();
    }
}
