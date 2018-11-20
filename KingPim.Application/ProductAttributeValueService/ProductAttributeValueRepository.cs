using KingPim.Domain.Entities;
using KingPim.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application.ProductAttributeValueService
{
    public class ProductAttributeValueRepository : IProductAttributeValueRepository
    {
        private KingPimDbContext ctx;
        public ProductAttributeValueRepository(KingPimDbContext context)
        {
            ctx = context;
        }
        public IEnumerable<ProductAttributeValue> ProductAttributeValues => ctx.ProductAttributeValues;
        public IEnumerable<ProductAttributeValue> GetAllProductAttributeValues()
        {
            return ProductAttributeValues;
        }
    }
}
