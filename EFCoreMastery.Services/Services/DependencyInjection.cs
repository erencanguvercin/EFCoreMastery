using EFCoreMastery.Services.Interfaces.Category;
using EFCoreMastery.Services.Interfaces.Customer;
using EFCoreMastery.Services.Interfaces.Order;
using EFCoreMastery.Services.Interfaces.Product;
using EFCoreMastery.Services.Services.Category;
using EFCoreMastery.Services.Services.Customer;
using EFCoreMastery.Services.Services.Order;
using EFCoreMastery.Services.Services.Product;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EFCoreMastery.Services.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Servis Kayıtları
            //services.AddScoped<IGetActiveProductsByCategoryIdService, GetAllActiveProductsByCategoryId>();
            //services.AddScoped<IGetOrdersAndTotalAmountByCustomerIdService, GetOrdersAndTotalAmountByCustomerId>();
            //services.AddScoped<IGetAllActiveProductsWithTheirsCategoryNameService, GetAllActiveProductsWithTheirsCategoryName>();
            //services.AddScoped<IGetAllOrdersWithCustomerDetailService, GetAllOrdersWithCustomerDetailService>();
            //services.AddScoped<IGetFilteredOrderReportService, GetFilteredOrderReportService>();
            //services.AddScoped<IGetCategoryReportService, GetCategoryReportService>();
            //services.AddScoped<IGetVIPCustomerReportService, GetVIPCustomerReportService>();
            //services.AddScoped<ISearchProductsByNameService, SearchProductsByNameService>();
            //services.AddScoped<IGetTopExpensiveProductsService, GetTopExpensiveProductsService>();
            //services.AddScoped<IGetPagedProductsService, GetPagedProductsService>();
            //services.AddScoped<IGetPagedProductsBySearchService, GetPagedProductsBySearchService>();
            //services.AddScoped<IGetPagedProductsWithSortingService, GetPagedProductsWithSortingService>();
            //services.AddScoped<IGetPagedProductsWithCategoryService, GetPagedProductsWithCategoryService>();
            //return services;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
