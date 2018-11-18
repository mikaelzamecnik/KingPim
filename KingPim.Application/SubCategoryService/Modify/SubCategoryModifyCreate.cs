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

            if (model.Id == 0)     // Create
            {
                // If the Subcategory has any connecting Attribute Groups.
                if (model.AttributeGroupId != null)
                {
                    var subcatAttrGroupList = new List<SubcategoryAttributeGroup>();
                    foreach (var attrGroupId in model.AttributeGroupId)
                    {
                        var vmSubcatAttrGroup = new SubcategoryAttributeGroup
                        {
                            SubcategoryId = model.Id,
                            AttributeGroupId = attrGroupId
                        };
                        subcatAttrGroupList.Add(vmSubcatAttrGroup);
                    }
                    var newSubcat = new SubCategory
                    {
                        Name = model.Name,
                        CategoryId = model.CategoryId,
                        Products = null,
                        SubcategoryAttributeGroups = subcatAttrGroupList,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        PublishedStatus = false,
                        Version = 1,
                    };
                    _context.SubCategories.Add(newSubcat);
                }
                else
                {
                    // Otherwise will save SubcategoryAttributeGroups as null.
                    var newSubcat = new SubCategory
                    {
                        Name = model.Name,
                        CategoryId = model.CategoryId,
                        Products = null,
                        SubcategoryAttributeGroups = null,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        PublishedStatus = false,
                        Version = 1,
                    };
                    _context.SubCategories.Add(newSubcat);
                }
            }
            else     // Update
            {
                var ctxSubcategory = _context.SubCategories.FirstOrDefault(x => x.Id.Equals(model.Id));
                var ctxSubcatAttrGroups = _context.SubcategoryAttributeGroups.Where(x => x.SubcategoryId == model.Id);
                // Remove the subcat attribute group connection from DB first.
                _context.SubcategoryAttributeGroups.RemoveRange(ctxSubcatAttrGroups);
                var subcatAttrGroupList = new List<SubcategoryAttributeGroup>();
                foreach (var attrGroupId in model.AttributeGroupId)
                {
                    var vmSubcatAttrGroup = new SubcategoryAttributeGroup
                    {
                        SubcategoryId = model.Id,
                        AttributeGroupId = attrGroupId
                    };
                    subcatAttrGroupList.Add(vmSubcatAttrGroup);
                }
                if (ctxSubcategory != null)
                {
                    ctxSubcategory.Name = model.Name;
                    ctxSubcategory.CategoryId = model.CategoryId;
                    ctxSubcategory.SubcategoryAttributeGroups = subcatAttrGroupList;
                    ctxSubcategory.DateUpdated = DateTime.Now;
                    ctxSubcategory.Version = ctxSubcategory.Version + 1;
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}