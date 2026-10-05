using EFCoreMastery.Services.DTOs.Common;
using EFCoreMastery.Services.Features.Products.Queries.GetPagedProductsWithFilter;
using EFCoreMastery.Services.Results.Concretes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMastery.WebApp.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        // Ürünleri filtreli, sıralı ve sayfalı getiren MediatR Query Endpoint'i
        [HttpGet]
        public async Task<IActionResult> GetPagedProductsAsync([FromQuery] GetPagedProductsWithFilterQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);
            return Ok(new TypedSuccessResult<PagedResultDto<GetPagedProductsWithFilterQueryResponse>>(result));
        }
    }
}
