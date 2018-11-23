using KingPim.Application.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.Repositories.Interfaces
{
    public interface IProductAttributeRepo
    {
        Task<IEnumerable<ProductAttributeModel>> GetProductattributes();
        Task<ProductAttributeModel> GetProductattribute(int id);
        Task CreateProductattribute(ProductAttributeModel model);
        Task UpdateProductattribute(ProductAttributeModel model);
        Task DeleteProductattribute(int id);
    }
}
