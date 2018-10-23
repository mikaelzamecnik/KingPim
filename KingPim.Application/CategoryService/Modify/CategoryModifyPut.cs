using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.CategoryService.Modify
{
    public class CategoryModifyPut:ICategoryModifyPut
        {
        public readonly KingPimDbContext _context;

        public CategoryModifyPut(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(CategoryModifyPutModel model)
        {
            var entity = await _context.Categories.SingleAsync(c => c.Id == model.Id);
                {
                    entity.Id = model.Id;
                    entity.Name = model.Name;

                     _context.Categories.Add(entity);

                await _context.SaveChangesAsync();
                }
               
        }
    }
}