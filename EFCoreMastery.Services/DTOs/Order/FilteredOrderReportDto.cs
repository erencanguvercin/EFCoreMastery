using EFCoreMastery.Domain.Enums;

namespace EFCoreMastery.Services.DTOs.Order
{
    public class FilteredOrderReportDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string CustomerFullName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
    }
}
