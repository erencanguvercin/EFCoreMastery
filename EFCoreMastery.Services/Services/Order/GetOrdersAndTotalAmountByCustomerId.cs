
using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Order;
using EFCoreMastery.Services.Interfaces.Order;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Services.Services.Order
{
    public class GetOrdersAndTotalAmountByCustomerId(AppDbContext context) : IGetOrdersAndTotalAmountByCustomerIdService
    {
        
        public async Task<List<CustomerOrderListDto>> GetOrdersAndTotalAmountByCustomerIdAsync(int customerId)
        {
            return await context.Orders.AsNoTracking().Where(o=>o.CustomerId == customerId).Select(o => new CustomerOrderListDto
            {
                OrderDate = o.OrderDate,
                OrderId = o.Id,
                OrderStatus = o.OrderStatus,
                PaymentMethod = o.PaymentMethod,
                TotalAmount = o.TotalAmount
                
            }).ToListAsync();
        }
    }
}
