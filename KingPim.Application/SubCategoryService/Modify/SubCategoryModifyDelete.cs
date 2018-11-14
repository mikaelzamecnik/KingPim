using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.SubCategoryService.Modify
{
    public class SubCategoryModifyDelete:ISubCategoryModifyDelete
    {
        public readonly KingPimDbContext _context;

        public SubCategoryModifyDelete(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(int id)
        {
            var entity = await _context.SubCategories.SingleAsync(c => c.Id == id);
            _context.SubCategories.Remove(entity);

            await _context.SaveChangesAsync();

        }
    }
}