using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.CategoryService.Modify
{
    public class CategoryModifyDelete:ICategoryModifyDelete
    {
        public readonly KingPimDbContext _context;

        public CategoryModifyDelete(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(int id)
        {
            var entity = await _context.Categories.SingleAsync(c => c.CategoryID == id);
            _context.Categories.Remove(entity);

            await _context.SaveChangesAsync();

        }
    }
}