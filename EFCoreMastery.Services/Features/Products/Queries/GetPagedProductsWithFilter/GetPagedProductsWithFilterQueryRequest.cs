using EFCoreMastery.Services.DTOs.Common;
using MediatR;

namespace EFCoreMastery.Services.Features.Products.Queries.GetPagedProductsWithFilter
{
    public record GetPagedProductsWithFilterQueryRequest : IRequest<PagedResultDto<GetPagedProductsWithFilterQueryResponse>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public string? SortBy { get; init; } = string.Empty;
        public decimal? MaxPrice { get; init; }
        public decimal? MinPrice { get; init; }
        public string? SearchTerm { get; init; } = string.Empty;
        public int? CategoryId { get; init; }
        public bool IsDescending { get; init; } = false;
    }
}
