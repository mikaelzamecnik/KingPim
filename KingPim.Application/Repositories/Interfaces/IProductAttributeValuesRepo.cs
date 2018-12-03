using KingPim.Application.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.Repositories.Interfaces
{
    public interface IProductAttributeValueRepo
    {
        Task<IEnumerable<ProductAttributeValuesModel>> GetProductattributevalues();
        Task<ProductAttributeValuesModel> GetProductattributevalue(int id);
        Task CreateProductattributevalue(ProductAttributeValuesModel model);
        Task UpdateProductattributevalue(ProductAttributeValuesModel model);
        Task DeleteProductattributevalue(int id);
    }
}
