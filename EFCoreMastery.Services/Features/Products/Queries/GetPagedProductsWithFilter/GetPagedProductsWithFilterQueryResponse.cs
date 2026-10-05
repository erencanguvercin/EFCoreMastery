namespace EFCoreMastery.Services.Features.Products.Queries.GetPagedProductsWithFilter
{
    public class GetPagedProductsWithFilterQueryResponse
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public decimal UnitPrice { get; init; }
        public int StockQuantity { get; init; }
        public string CategoryName { get; init; } = string.Empty;
    }
}
