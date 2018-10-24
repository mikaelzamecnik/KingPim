using System.Collections.Generic;
using System.Threading.Tasks;


namespace KingPim.Application.ProductService.Get
{
    public interface IProductGetSingle
    {
        Task<ProductGetSingleModel> Execute(int id);
    }
}