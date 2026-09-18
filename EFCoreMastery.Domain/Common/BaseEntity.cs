
using EFCoreMastery.Domain.Interfaces;

namespace EFCoreMastery.Domain.Common
{
    public abstract class BaseEntity : IAuditableEntity, ISoftDelete
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
