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

        public IEnumerable<Product> Products => _context.Products.Include(c => c.ProductID).Include(d => d.SubCategory);
        public async Task<IEnumerable<ProductGetAllModel>> Execute()
        {
            return await _context.Products.Select(c =>
                new ProductGetAllModel
                {
                 ProductID = c.ProductID,
                 ProductName = c.ProductName,
                 DateCreated = c.DateCreated,
                 DateUpdated = c.DateUpdated,
                 EditedBy = c.EditedBy,
                 Version = c.Version,
                 SubCategory = c.SubCategory,
                 PublishedStatus = c.PublishedStatus

        }).ToListAsync();
        }
    }
}