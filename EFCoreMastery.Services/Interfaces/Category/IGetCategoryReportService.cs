using EFCoreMastery.Services.DTOs.Category;

namespace EFCoreMastery.Services.Interfaces.Category
{
    public interface IGetCategoryReportService
    {
        Task<List<CategoryReportDto>> GetCategoryReportAsync();
    }
}
