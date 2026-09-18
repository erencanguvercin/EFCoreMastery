using EFCoreMastery.Services.Interfaces.Order;
using EFCoreMastery.Services.Interfaces.Product;
using EFCoreMastery.Services.Services.Order;
using EFCoreMastery.Services.Services.Product;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreMastery.Services.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Servis Kayıtları
            services.AddScoped<IGetActiveProductsByCategoryIdService, GetAllActiveProductsByCategoryId>();
            services.AddScoped<IGetOrdersAndTotalAmountByCustomerIdService, GetOrdersAndTotalAmountByCustomerId>();
            services.AddScoped<IGetAllActiveProductsWithTheirsCategoryNameService, GetAllActiveProductsWithTheirsCategoryName>();
            services.AddScoped<IGetAllOrdersWithCustomerDetailService, GetAllOrdersWithCustomerDetailService>();
            return services;
        }
    }
}
