using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Application.ProductAttributeValueService;

namespace KingPim.Application.ProductService.Modify
{
    public interface IProductModifyCreate
    {
        Task Execute(ProductModifyCreateModel model);
        void SaveProductAttributeValue(ProductAttributeValueModel model);
    }
}