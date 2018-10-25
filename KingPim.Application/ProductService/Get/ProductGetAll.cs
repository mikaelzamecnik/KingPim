using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.ProductService.Get
{
    public class ProductGetAll:IProductGetAll
    {
        public readonly KingPimDbContext _context;

        public ProductGetAll(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductGetAllModel>> Execute()
        {
            return await _context.Products.Select(c =>
                new ProductGetAllModel
                {
                   Id = c.Id,
                   Name = c.Name,
                   DateCreated = c.DateCreated,
                   DateUpdated = c.DateUpdated,
                   EditedBy = c.EditedBy,
                   Version = c.Version,
                   PublishedStatus = c.PublishedStatus,
                   CategoryId = c.Category.Name,
                   SubCategoryId = c.SubCategory.Name
                }).ToListAsync();
        }
    }
}