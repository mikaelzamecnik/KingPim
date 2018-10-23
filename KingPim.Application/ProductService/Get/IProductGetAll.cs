using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.ProductService.Get
{
    public interface IProductGetAll
    {
        Task<IEnumerable<ProductGetAllModel>> Execute();
    }
}