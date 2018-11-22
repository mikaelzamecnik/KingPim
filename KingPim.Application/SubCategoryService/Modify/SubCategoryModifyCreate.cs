using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;
using System;

namespace KingPim.Application.SubCategoryService.Modify
{
    public class SubCategoryModifyCreate : ISubCategoryModifyCreate
    {
        public readonly KingPimDbContext _context;

        public SubCategoryModifyCreate(KingPimDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SubCategory> SubCategories => _context.SubCategories;
        public async Task Execute(SubCategoryModifyCreateModel model)
        {

            var entity = new SubCategory
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                PublishedStatus = false,
                Version = 1,
            };
            _context.SubCategories.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}