using EFCoreMastery.Services.DTOs.Order;

namespace EFCoreMastery.Services.Interfaces.Order
{
    public interface IGetOrdersAndTotalAmountByCustomerIdService
    {
        Task<List<CustomerOrderListDto>> GetOrdersAndTotalAmountByCustomerIdAsync(int customerId);
    }
}
