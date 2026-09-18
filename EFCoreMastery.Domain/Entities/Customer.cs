using EFCoreMastery.Domain.Common;

namespace EFCoreMastery.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        //Navigation Properties
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
