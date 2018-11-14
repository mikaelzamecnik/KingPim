using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;

namespace KingPim.Application.ProductService.Modify
{
    public class ProductModifyDelete: IProductModifyDelete
    {
        public readonly KingPimDbContext _context;

        public ProductModifyDelete(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(int id)
        {
            var entity = await _context.Products.SingleAsync(c => c.Id == id);
            _context.Products.Remove(entity);

            await _context.SaveChangesAsync();

        }
    }
}