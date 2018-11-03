using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.SubCategoryService.Modify
{
    public class SubCategoryModifyPut:ISubCategoryModifyPut
        {
        public readonly KingPimDbContext _context;

        public SubCategoryModifyPut(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(SubCategoryModifyPutModel model)
        {
            var entity = await _context.SubCategories.SingleAsync(c => c.SubcategoryID == model.Id);
                {
                    entity.SubcategoryID = model.Id;
                    entity.SubcategoryName = model.Name;

                     _context.SubCategories.Add(entity);

                await _context.SaveChangesAsync();
                }

        }
    }
}