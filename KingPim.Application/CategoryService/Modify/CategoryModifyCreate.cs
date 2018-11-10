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
                    CategoryID = model.CategoryID,
                    CategoryName = model.CategoryName,
                    CatalogId = model.CatalogId
                };
                _context.Categories.Add(entity);

                await _context.SaveChangesAsync();
        }
    }
}