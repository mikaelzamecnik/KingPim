using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Application.ProductAttributeValue;

namespace KingPim.Application.ProductService.Modify
{
    public interface IProductModifyCreate
    {
        Task Execute(ProductModifyCreateModel model);
        void SaveProductAttributeValue(ProductAttributeValueModel model);
    }
}