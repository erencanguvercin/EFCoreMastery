using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Order;
using EFCoreMastery.Services.Interfaces.Order;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Services.Services.Order
{
    public class GetFilteredOrderReportService(AppDbContext context) : IGetFilteredOrderReportService
    {
        public async Task<List<FilteredOrderReportDto>> GetFilteredOrderReportAsync(DateTime startDate, DateTime endDate)
        {
            return await context.Orders.AsNoTracking().Where(o => o.PaymentMethod == Domain.Enums.PaymentMethod.CreditCard && o.OrderStatus != Domain.Enums.OrderStatus.Cancelled && o.OrderDate>= startDate && o.OrderDate<= endDate).Select(o => new FilteredOrderReportDto
            {
                OrderId = o.Id,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                PaymentMethod = o.PaymentMethod,
                CustomerFullName = $"{o.Customer.FirstName} {o.Customer.LastName}",
                CustomerEmail = o.Customer.Email
            }).ToListAsync();
        }
    }
}
