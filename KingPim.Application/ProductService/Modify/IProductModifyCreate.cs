using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.ProductService.Modify
{
    public interface IProductModifyCreate
    {
        Task Execute(ProductModifyCreateModel model);
    }
}