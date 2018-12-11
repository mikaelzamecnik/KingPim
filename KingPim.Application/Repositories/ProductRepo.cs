using KingPim.Application.Repositories.Models;
using KingPim.Application.Repositories.Interfaces;
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
    public class ProductRepo : IProductRepo
    {

        public readonly KingPimDbContext _context;

        public ProductRepo(KingPimDbContext context)
        {
            _context = context;
        }


        // Get All Products
        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            return await _context.Products.Select(c =>
                new ProductModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateUpdated,
                    EditedBy = c.EditedBy,
                    Version = c.Version,
                    SubCategory = c.SubCategory,
                    PublishedStatus = c.PublishedStatus,
                    ProductAttributes = c.ProductAttributes,
                    ProductAttributeValues = c.ProductAttributeValues


                }).ToListAsync();
        }

        // Get Single Product
        public async Task<ProductModel> GetProduct(int id)
        {
            var entity = await _context.Products.FindAsync(id);

            if (entity == null)
                return null;

            return new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                DateCreated = entity.DateCreated,
                DateUpdated = entity.DateUpdated,
                EditedBy = entity.EditedBy,
                Version = entity.Version,
                SubCategory = entity.SubCategory,
                PublishedStatus = entity.PublishedStatus,
                ProductAttributes = entity.ProductAttributes,
                ProductAttributeValues = entity.ProductAttributeValues

            };
        }

        // Create new Product
        public async Task CreateProduct(ProductModel model)
        {
                var entity = new Product
                {

                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    DateCreated = model.DateCreated,
                    EditedBy = model.EditedBy,
                    Version = 1,
                    PublishedStatus = model.PublishedStatus,
                    SubCategoryId = model.SubCategoryId,
                    SubCategory = model.SubCategory

                };
                _context.Products.Add(entity);

                await _context.SaveChangesAsync();
        }

        // Update Product
        public async Task UpdateProduct(ProductModel model)
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


                var entity = await _context.Products.SingleAsync(c => c.Id == model.Id);
                {
                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    entity.DateUpdated = model.DateUpdated;
                    entity.EditedBy = model.EditedBy;
                    entity.Version = entity.Version + 1;

                    _context.Products.Update(entity);

                }

                await _context.SaveChangesAsync();

            }
        }

        // Delete Product
        public async Task DeleteProduct(int id)
        {
            var entity = await _context.Products.SingleAsync(c => c.Id == id);
            _context.Products.Remove(entity);

            await _context.SaveChangesAsync();

        }

        // Return All products for export
        public IEnumerable<Product> Products => _context.Products;
        public IEnumerable<Product> GetAllProductsExport()
        {
            return Products;
        }
    }
}
