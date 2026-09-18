using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Order;
using EFCoreMastery.Services.Interfaces.Order;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Services.Services.Order
{
    public class GetAllOrdersWithCustomerDetailService(AppDbContext context) : IGetAllOrdersWithCustomerDetailService
    {
        public async Task<List<OrderDetailListDto>> GetAllOrdersWithCustomerDetailAsync()
        {
            return await context.Orders.AsNoTracking().Select(o => new OrderDetailListDto
            {
                OrderId=o.Id,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                CustomerFullName = $"{o.Customer.FirstName} {o.Customer.LastName}",
            }).ToListAsync();
        }
    }
}
