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
    public class SubCategoryRepo:ISubCategoryRepo
    {
        public readonly KingPimDbContext _context;

        public SubCategoryRepo(KingPimDbContext context)
        {
            _context = context;
        }


        // Get All SubCategories
        public async Task<IEnumerable<SubCategoryModel>> GetSubcategories()
        {
            return await _context.SubCategories.Select(c =>
                new SubCategoryModel
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

        // Get Single SubCategory
        public async Task<SubCategoryModel> GetSubcategory(int id)
        {
            var entity = await _context.SubCategories.FindAsync(id);

            if (entity == null)
                return null;

            return new SubCategoryModel
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

        // Create new SubCategory
        public async Task CreateSubcategory(SubCategoryModel model)
        {
            try
            {
                var entity = new SubCategory
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    DateCreated = model.DateCreated,
                    EditedBy = model.EditedBy,
                    Version = model.Version,
                    PublishedStatus = model.PublishedStatus,

                };
                _context.SubCategories.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        // Update SubCategory
        public async Task UpdateSubcategory(SubCategoryModel model)
        {
            var entity = await _context.SubCategories.SingleAsync(c => c.Id == model.Id);
            {
                entity.Id = model.Id;
                entity.Name = model.Name;

                _context.SubCategories.Update(entity);

                await _context.SaveChangesAsync();
            }
        }

        // Delete SubCategory
        public async Task DeleteSubcategory(int id)
        {
            var entity = await _context.SubCategories.SingleAsync(c => c.Id == id);
            _context.SubCategories.Remove(entity);

            await _context.SaveChangesAsync();

        }

        // Return All subcategories for export
        public IEnumerable<SubCategory> SubCategories => _context.SubCategories;
        public IEnumerable<SubCategory> GetAllSubCategoriesExport()
        {
            return SubCategories;
        }
    }
}
