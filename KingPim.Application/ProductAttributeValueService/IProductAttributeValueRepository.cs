using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application.ProductAttributeValueService
{
    public interface IProductAttributeValueRepository
    {
        IEnumerable<ProductAttributeValue> ProductAttributeValues { get; }
        IEnumerable<ProductAttributeValue> GetAllProductAttributeValues();
    }
}
