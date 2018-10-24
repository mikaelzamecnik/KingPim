using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.ProductService.Modify
{
    public class ProductModifyCreate : IProductModifyCreate
    {
        public readonly KingPimDbContext _context;

        public ProductModifyCreate(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(ProductModifyCreateModel model)
        {
            var entity = new Product
                {

                Id = model.Id,
                Name = model.Name,
                DateCreated = model.DateCreated,
                DateUpdated = model.DateUpdated,
                EditedBy = model.EditedBy,
                Version = model.Version,
                PublishedStatus = model.PublishedStatus,
                SubCategoryId = model.SubCategoryId
            };
                _context.Products.Add(entity);

                await _context.SaveChangesAsync();
        }
    }
}