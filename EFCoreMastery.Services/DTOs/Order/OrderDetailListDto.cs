namespace EFCoreMastery.Services.DTOs.Order
{
    public class OrderDetailListDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerFullName { get; set; } = string.Empty;
    }
}
