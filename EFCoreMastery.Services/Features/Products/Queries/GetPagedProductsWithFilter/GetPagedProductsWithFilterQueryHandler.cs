using EFCoreMastery.Persistence;
using EFCoreMastery.Services.DTOs.Common;
using EFCoreMastery.Services.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EFCoreMastery.Services.Features.Products.Queries.GetPagedProductsWithFilter
{
    public class GetPagedProductsWithFilterQueryHandler(AppDbContext context) : IRequestHandler<GetPagedProductsWithFilterQueryRequest, PagedResultDto<GetPagedProductsWithFilterQueryResponse>>
    {
        public async Task<PagedResultDto<GetPagedProductsWithFilterQueryResponse>> Handle(GetPagedProductsWithFilterQueryRequest request, CancellationToken cancellationToken)
        {
            var query = context.Products.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(p => EF.Functions.ILike(p.Name, $"%{request.SearchTerm}%"));
            }
            if(request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.CategoryId == request.CategoryId.Value);
            }
            if(request.MinPrice.HasValue && request.MinPrice.Value >= 0)
            {
                query = query.Where(p => p.UnitPrice >= request.MinPrice);
            }
            if(request.MaxPrice.HasValue && request.MaxPrice.Value >= 0)
            {
                query = query.Where(p => p.UnitPrice <= request.MaxPrice);
            }

            Expression<Func<Domain.Entities.Product, object>> keySelector = request.SortBy?.Trim().ToLowerInvariant() switch
            {
                "name" => p => p.Name,
                "price" or "unitprice" => p => p.UnitPrice,
                "stock" or "stockquantity" => p => p.StockQuantity,
                "category" or "categoryname" => p => p.Category.Name,
                _ => p => p.Id
            };

            query = request.IsDescending ? query.OrderByDescending(keySelector) : query.OrderBy(keySelector);

            return await query.ToPagedResultAsync(request.PageNumber, request.PageSize, p => new GetPagedProductsWithFilterQueryResponse
            {
                Id = p.Id,
                Name = p.Name,
                StockQuantity = p.StockQuantity,
                UnitPrice = p.UnitPrice,
                CategoryName = p.Category.Name
            });
        }
    }
}
