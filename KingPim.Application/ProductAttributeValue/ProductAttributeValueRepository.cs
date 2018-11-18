using KingPim.Domain.Entities;
using KingPim.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application
{
    public class ProductAttributeValueRepository : IProductAttributeValueRepository
    {
        private KingPimDbContext ctx;
        public ProductAttributeValueRepository(KingPimDbContext context)
        {
            ctx = context;
        }
        public IEnumerable<Domain.Entities.ProductAttributeValue> ProductAttributeValues => ctx.ProductAttributeValues;
        public IEnumerable<Domain.Entities.ProductAttributeValue> GetAllProductAttributeValues()
        {
            return ProductAttributeValues;
        }
    }
}
