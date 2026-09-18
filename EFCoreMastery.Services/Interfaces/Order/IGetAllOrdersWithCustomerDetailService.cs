using EFCoreMastery.Services.DTOs.Order;


namespace EFCoreMastery.Services.Interfaces.Order
{
    public interface IGetAllOrdersWithCustomerDetailService
    {
        Task<List<OrderDetailListDto>> GetAllOrdersWithCustomerDetailAsync();
    }
}
