using EFCoreMastery.Domain.Common;

namespace EFCoreMastery.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string SKU { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }

        //Navigation Properties
        public Category Category { get; set; } = null!;
        public ProductDetail? ProductDetail { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
