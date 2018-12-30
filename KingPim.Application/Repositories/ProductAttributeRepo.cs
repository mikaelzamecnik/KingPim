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
    public class ProductAttributeRepo:IProductAttributeRepo
    {
        public readonly KingPimDbContext _context;

        public ProductAttributeRepo(KingPimDbContext context)
        {
            _context = context;
        }


        // Get All ProductAttributes
        public async Task<IEnumerable<ProductAttributeModel>> GetProductattributes()
        {
            return await _context.ProductAttributes.Select(c =>
                new ProductAttributeModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Type = c.Type,
                    Description = c.Description,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateUpdated,
                    PublishedStatus = c.PublishedStatus,
                    EditedBy = c.EditedBy,
                    Version = c.Version
                }).ToListAsync();
        }

        // Get Single ProductAttribute
        public async Task<ProductAttributeModel> GetProductattribute(int id)
        {
            var entity = await _context.ProductAttributes.FindAsync(id);

            if (entity == null)
                return null;

            return new ProductAttributeModel
            {
                Id = entity.Id,
                Type = entity.Type,
                Name = entity.Name,
                Description = entity.Description,
                DateCreated = entity.DateCreated,
                DateUpdated = entity.DateUpdated,
                PublishedStatus = entity.PublishedStatus,
                EditedBy = entity.EditedBy,
                Version = entity.Version

            };
        }

        // Create new ProductAttributes
        public async Task CreateProductattribute(ProductAttributeModel model)
        {
            try
            {
                var entity = new ProductAttribute
                {

                    Id = model.Id,
                    Type = model.Type,
                    Name = model.Name,
                    Description = model.Description,
                    DateCreated = model.DateCreated,
                    EditedBy = model.EditedBy,
                    Version = model.Version,
                    PublishedStatus = model.PublishedStatus,
                    AttributeGroupId = model.AttributeGroupId,
                    ProductAttributeValueId = model.ProductAttributeValueId,
                    AttributeOptionsListId = model.AttributeOptionsListId,
                    AttributeOptionList = model.AttributeOptionList

                };
                _context.ProductAttributes.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        // Update ProductAttributes
        public async Task UpdateProductattribute(ProductAttributeModel model)
        {
            var entity = await _context.ProductAttributes.SingleAsync(c => c.Id == model.Id);
            {
                entity.Id = model.Id;
                entity.Name = model.Name;

                _context.ProductAttributes.Update(entity);

                await _context.SaveChangesAsync();
            }
        }

        // Delete ProductAttributes
        public async Task DeleteProductattribute(int id)
        {
            var entity = await _context.ProductAttributes.SingleAsync(c => c.Id == id);
            _context.ProductAttributes.Remove(entity);

            await _context.SaveChangesAsync();

        }
    }
}
