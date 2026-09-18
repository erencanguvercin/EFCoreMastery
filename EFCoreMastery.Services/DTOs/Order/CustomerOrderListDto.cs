using EFCoreMastery.Domain.Enums;

namespace EFCoreMastery.Services.DTOs.Order
{
    public class CustomerOrderListDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
