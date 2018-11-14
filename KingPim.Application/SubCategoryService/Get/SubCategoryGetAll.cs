using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;

namespace KingPim.Application.SubCategoryService.Get
{
    public class SubCategoryGetAll:ISubCategoryGetAll
    {
        public readonly KingPimDbContext _context;

        public SubCategoryGetAll(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubCategoryGetAllModel>> Execute()
        {
            return await _context.SubCategories.Select(c =>
                new SubCategoryGetAllModel
                {
                    Id = c.SubcategoryID,
                    Name = c.SubcategoryName,
                    Category = c.Category
                    


                }).ToListAsync();
        }
    }
}