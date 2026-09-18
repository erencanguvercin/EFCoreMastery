using EFCoreMastery.Domain.Entities;
using EFCoreMastery.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastery.Persistence
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            // 1. Bekleyen migration varsa uygulamayı başlatırken otomatik DB'ye uygular
            await context.Database.MigrateAsync();

            //Veri zaten varsa tekrar ekleme yapmasın (Idempotent)

            if(await context.Categories.AnyAsync())
            {
                return;
            }

            // 2. Parent-Child Kategorilerin Eklenmesi

            var electronics = new Category { Name = "Elektronik" };
            var clothing = new Category { Name = "Giyim" };

            await context.Categories.AddRangeAsync(electronics, clothing);
            await context.SaveChangesAsync(); // Parent ID'lerin oluşması için kaydediyoruz.

            var computers = new Category { Name = "Bilgisayar", ParentCategoryId = electronics.Id };
            var phones = new Category { Name = "Telefon", ParentCategoryId = electronics.Id };
            var mensClothing = new Category { Name = "Erkek Giyim", ParentCategoryId = clothing.Id };

            await context.Categories.AddRangeAsync(computers, phones, mensClothing);
            await context.SaveChangesAsync();

            // 3. Ürünler ve One-To-One ProductDetail Yapısı

            var laptop = new Product
            {
                Name="Workstation Laptop 16GB",
                SKU="PRD-NB-001",
                UnitPrice = 45000.00m,
                StockQuantity = 15,
                CategoryId = computers.Id,
                ProductDetail = new ProductDetail
                {
                    Specifications = "32GB RAM, 1TB NVMe SSD, M3 Pro",
                    Weight = 1.8
                }
            };

            var smartphone = new Product
            {
                Name="Flagship Smartphone",
                SKU = "PRD-PH-002",
                UnitPrice = 32000.00m,
                StockQuantity =25,
                CategoryId = phones.Id,
                ProductDetail = new ProductDetail
                {
                    Specifications="6.7 inc OLED, 120Hz, 50MP Camera",
                    Weight = 0.21
                }
            };

            var shirt = new Product
            {
                Name = "Pamuklu Slim-Fit Gömlek",
                SKU = "PRD-CL-003",
                UnitPrice = 899.90m,
                StockQuantity = 100,
                CategoryId = mensClothing.Id
            };

            await context.Products.AddRangeAsync(laptop, smartphone, shirt);
            await context.SaveChangesAsync();

            // 4. Müşteriler

            var customer1 = new Customer { FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet.yilmaz@example.com" };
            var customer2 = new Customer { FirstName = "Ayşe", LastName = "Kaya", Email = "ayse.kaya@example.com" };

            await context.Customers.AddRangeAsync(customer1, customer2);
            await context.SaveChangesAsync();


            // 5. Siparişler ve Many-To-Many OrderItem Yapısı

            var order1 = new Order
            {
                CustomerId=customer1.Id,
                OrderDate = DateTime.UtcNow.AddDays(-5),
                OrderStatus = OrderStatus.Delivered,
                PaymentMethod = PaymentMethod.CreditCard,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem{ProductId=laptop.Id,Quantity=1,UnitPrice=laptop.UnitPrice},
                    new OrderItem{ProductId=shirt.Id,Quantity=2,UnitPrice=shirt.UnitPrice}
                }
            };

            order1.TotalAmount = order1.OrderItems.Sum(x => x.Quantity * x.UnitPrice);

            var order2 = new Order
            {
                CustomerId=customer2.Id,
                OrderDate = DateTime.UtcNow.AddDays(-1),
                OrderStatus = OrderStatus.Pending,
                PaymentMethod = PaymentMethod.BankTransfer,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem{ProductId=smartphone.Id,Quantity=1,UnitPrice=smartphone.UnitPrice}
                }
            };

            order2.TotalAmount = order2.OrderItems.Sum(x => x.Quantity * x.UnitPrice);

            await context.Orders.AddRangeAsync(order1, order2);
            await context.SaveChangesAsync();

        }
    }
}
