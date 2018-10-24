using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.CategoryService.Modify
{
    public class CategoryModifyCreate:ICategoryModifyCreate
        {
        public readonly KingPimDbContext _context;

        public CategoryModifyCreate(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(CategoryModifyCreateModel model)
        {
            var entity = new Category
                {
                    Id = model.Id,
                    Name = model.Name
                };
                _context.Categories.Add(entity);

                await _context.SaveChangesAsync();
        }
    }
}