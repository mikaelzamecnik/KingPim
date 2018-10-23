using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;

namespace KingPim.Application.CategoryService.Get
{
    public class CategoryGetSingle:ICategoryGetSingle
    {
        public readonly KingPimDbContext _context;

        public CategoryGetSingle(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryGetSingleModel> Execute(int id)
        {
            var entity = await _context.Categories.FindAsync(id);

            if (entity == null)
            return null;

            return new CategoryGetSingleModel
                {
                    Id = entity.Id,
                    Name = entity.Name
                };
        }
    }
}