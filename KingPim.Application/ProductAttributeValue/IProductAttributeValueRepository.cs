using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application
{
    public interface IProductAttributeValueRepository
    {
        IEnumerable<Domain.Entities.ProductAttributeValue> ProductAttributeValues { get; }
        IEnumerable<Domain.Entities.ProductAttributeValue> GetAllProductAttributeValues();
    }
}
