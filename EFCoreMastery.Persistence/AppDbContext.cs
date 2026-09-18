using EFCoreMastery.Domain.Entities;
using EFCoreMastery.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Persistence
{
    public class AppDbContext : DbContext
    {
        //Ctor Oluştur
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        //Database Tablolarını oluştur.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }


        //OnModelCreating override et.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. One-To-One Relationship Configuration (Product <-> ProductDetail)
            modelBuilder.Entity<Product>().HasOne(p => p.ProductDetail).WithOne(pd => pd.Product).HasForeignKey<ProductDetail>(pd => pd.ProductId);

            // 2. Self-Referencing (Category Parent-Child) Relationship Configuration
            modelBuilder.Entity<Category>().HasOne(c => c.ParentCategory).WithMany(pc => pc.SubCategories).HasForeignKey(x => x.ParentCategoryId).OnDelete(DeleteBehavior.Restrict);

            // 3. PostgreSQL Decimal - Numeric Sensitivity Settings
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasPrecision(18, 2);
            modelBuilder.Entity<OrderItem>().Property(oi => oi.UnitPrice).HasPrecision(18, 2);

            // 4. Global Soft-Delete Filter
            modelBuilder.Entity<Category>().HasQueryFilter(ca => !ca.IsDeleted);
            modelBuilder.Entity<Customer>().HasQueryFilter(cu => !cu.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(o => !o.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
        }

        //SaveChangesAsync Override Et.
       
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<IAuditableEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }




















    }
}
