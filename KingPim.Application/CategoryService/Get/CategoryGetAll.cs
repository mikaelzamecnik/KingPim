using KingPim.Domain.Entities;
using KingPim.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Application.CategoryService.Get
{
    public class CategoryGetAll:ICategoryGetAll
    {
        public readonly KingPimDbContext _context;

        public IEnumerable<Category> Categories => _context.Categories;
        public CategoryGetAll(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryGetAllModel>> Execute()
        {
            return await _context.Categories.Select(c =>
                new CategoryGetAllModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return Categories;
        }
    }
}