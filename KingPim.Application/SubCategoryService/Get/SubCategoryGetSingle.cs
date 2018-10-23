using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.SubCategoryService.Get
{
    public class SubCategoryGetSingle:ISubCategoryGetSingle
    {
        public readonly KingPimDbContext _context;

        public SubCategoryGetSingle(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task<SubCategoryGetSingleModel> Execute(int id)
        {
            var entity = await _context.SubCategories.FindAsync(id);

            if (entity == null)
            return null;

            return new SubCategoryGetSingleModel
                {
                    Id = entity.Id,
                    Name = entity.Name
                };
        }
    }
}