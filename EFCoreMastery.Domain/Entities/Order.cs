using EFCoreMastery.Domain.Common;
using EFCoreMastery.Domain.Enums;

namespace EFCoreMastery.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public OrderStatus OrderStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }

        //Navigation Properties

        public Customer Customer { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); 
    }
}
