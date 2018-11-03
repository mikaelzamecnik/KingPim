using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;


namespace KingPim.Application.ProductService.Get
{
    public class ProductGetSingle : IProductGetSingle
    {
        public readonly KingPimDbContext _context;

        public ProductGetSingle(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task<ProductGetSingleModel> Execute(int id)
        {
            var entity = await _context.Products.FindAsync(id);

            if (entity == null)
                return null;

            return new ProductGetSingleModel
            {
                Id = entity.ProductID,
                Name = entity.ProductName,
                DateCreated = entity.DateCreated,
                DateUpdated = entity.DateUpdated,
                EditedBy = entity.EditedBy,
                Version = entity.Version,
                PublishedStatus = entity.PublishedStatus,
                SubCategory = entity.SubCategory
            };
        }
    }
}