using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Customer;
using EFCoreMastery.Services.Interfaces.Customer;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Services.Services.Customer
{
    public class GetVIPCustomerReportService(AppDbContext context) : IGetVIPCustomerReportService
    {
        public async Task<List<VIPCustomerReportDto>> GetVIPCustomerReportAsync()
        {
            return await context.Customers.AsNoTracking().Where(c => c.Orders.Any(o => o.TotalAmount >= (decimal?)10000)).Select(c => new VIPCustomerReportDto
            {
                CustomerId = c.Id,
                CustomerFullName = $"{c.FirstName} {c.LastName}",
                Email = c.Email,
                TotalOrderCount = c.Orders.Count(),
                MaxOrderAmount = c.Orders.Max(o=>(decimal?)o.TotalAmount) ?? 0
            }).ToListAsync();
        }
    }
}
