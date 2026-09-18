using EFCoreMastery.Domain.Common;

namespace EFCoreMastery.Domain.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; } = null!;
        public int? ParentCategoryId { get; set; }

        //Navigation Properties
        public Category? ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
