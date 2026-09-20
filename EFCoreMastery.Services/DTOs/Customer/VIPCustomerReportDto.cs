namespace EFCoreMastery.Services.DTOs.Customer
{
    public class VIPCustomerReportDto
    {
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int TotalOrderCount { get; set; }
        public decimal MaxOrderAmount { get; set; }
    }
}
