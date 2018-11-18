using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.ProductService.Modify
{
    public class ProductModifyPut : IProductModifyPut
    {
        public readonly KingPimDbContext _context;

        public ProductModifyPut(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(ProductModifyPutModel model)
        {

            var ctxProduct = _context.Products.FirstOrDefault(p => p.Id.Equals(model.Id));
            if (ctxProduct != null)
            {
                // The products subcategory.
                var ctxSubcategory = _context.SubCategories.FirstOrDefault(s => s.Id.Equals(ctxProduct.SubCategoryId));
                // The products subcategories category.
                var ctxCategory = _context.Categories.FirstOrDefault(c => c.Id.Equals(ctxSubcategory.CategoryId));

                if (!ctxProduct.PublishedStatus)
                {
                    ctxProduct.PublishedStatus = true;
                    ctxSubcategory.PublishedStatus = true;
                    ctxCategory.PublishedStatus = true;
                }
                else
                {
                    ctxProduct.PublishedStatus = false;

                    // If all the subcategory products have false (unpublished) for all products, then the subcategory needs to also be false (unpublished).
                    if (ctxSubcategory.Products.Count(p => p.PublishedStatus) == 0)
                    {
                        ctxSubcategory.PublishedStatus = false;
                    }
                    // If all the category subcategories have false (unpublished) for all subcats, then the category needs to also be false (unpublished).
                    if (ctxCategory.SubCategories.Count(s => s.PublishedStatus) == 0)
                    {
                        ctxCategory.PublishedStatus = false;
                    }
                }


                    var entity =  await _context.Products.SingleAsync(c => c.Id == model.Id);
                {
                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    entity.DateUpdated = model.DateUpdated;
                    entity.EditedBy = model.EditedBy;
                    entity.Version = model.Version + 1;

                    _context.Products.Update(entity);
                    
                }

                await _context.SaveChangesAsync();

            }


                
        }
    }
}