namespace EFCoreMastery.Services.DTOs.Category
{
    public class CategoryReportDto
    {
        public string CategoryName { get; set; } = string.Empty;
        public int TotalProductCount { get; set; }
        public decimal AveragePrice { get; set; }
    }
}
