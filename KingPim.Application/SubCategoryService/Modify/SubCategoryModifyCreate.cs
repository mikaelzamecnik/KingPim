using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.SubCategoryService.Modify
{
    public class SubCategoryModifyCreate:ISubCategoryModifyCreate
        {
        public readonly KingPimDbContext _context;

        public SubCategoryModifyCreate(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(SubCategoryModifyCreateModel model)
        {
            var entity = new SubCategory
                {
                    SubcategoryID = model.Id,
                    SubcategoryName = model.Name
                };
                _context.SubCategories.Add(entity);

                await _context.SaveChangesAsync();
        }
    }
}