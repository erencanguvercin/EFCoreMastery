using EFCoreMastery.Services.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMastery.Services.Interfaces.Product
{
    public interface IGetTopExpensiveProductsService
    {
        Task<List<ProductListDto>> GetTopExpensiveProductsAsync(int count = 3);
    }
}
