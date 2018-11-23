using KingPim.Application.Repositories.Interfaces;
using KingPim.Application.Repositories.Models;
using KingPim.Domain.Entities;
using KingPim.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Application.Repositories
{
    public class CategoryRepo:ICategoryRepo
    {
        public readonly KingPimDbContext _context;

        public CategoryRepo(KingPimDbContext context)
        {
            _context = context;
        }

        // Get All Categories
        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            return await _context.Categories.Select(c =>
                new CategoryModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateUpdated,
                    PublishedStatus = c.PublishedStatus,
                    EditedBy = c.EditedBy,
                    Version = c.Version


                }).ToListAsync();
        }

        // Get Single Category
        public async Task<CategoryModel> GetCategory(int id)
        {
            var entity = await _context.Categories.FindAsync(id);

            if (entity == null)
                return null;

            return new CategoryModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                DateCreated = entity.DateCreated,
                DateUpdated = entity.DateUpdated,
                PublishedStatus = entity.PublishedStatus,
                EditedBy = entity.EditedBy,
                Version = entity.Version

            };
        }

        // Create new Category
        public async Task CreateCategory(CategoryModel model)
        {
            try
            {
                var entity = new Category
                {

                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    DateCreated = model.DateCreated,
                    EditedBy = model.EditedBy,
                    Version = model.Version,
                    PublishedStatus = model.PublishedStatus,

                };
                _context.Categories.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        // Update Category
        public async Task UpdateCategory(CategoryModel model)
        {
            var entity = await _context.Categories.SingleAsync(c => c.Id == model.Id);
            {
                entity.Id = model.Id;
                entity.Name = model.Name;

                _context.Categories.Add(entity);

                await _context.SaveChangesAsync();
            }
        }

        // Delete Category
        public async Task DeleteCategory(int id)
        {
            var entity = await _context.Categories.SingleAsync(c => c.Id == id);
            _context.Categories.Remove(entity);

            await _context.SaveChangesAsync();

        }

        // Return All categories for export
        public IEnumerable<Category> Categories => _context.Categories;
        public IEnumerable<Category> GetAllCategoriesExport()
        {
            return Categories;
        }
    }
}
