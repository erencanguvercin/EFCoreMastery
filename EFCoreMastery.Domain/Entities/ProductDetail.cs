using EFCoreMastery.Domain.Common;

namespace EFCoreMastery.Domain.Entities
{
    public class ProductDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public string Specifications { get; set; } = null!;
        public double Weight { get; set; }

        //Navigation Properties
        public Product Product { get; set; } = null!;
    }
}
