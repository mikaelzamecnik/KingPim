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
    public class ProductAttributeValuesRepo:IProductAttributeValueRepo
    {
        public readonly KingPimDbContext _context;

        public ProductAttributeValuesRepo(KingPimDbContext context)
        {
            _context = context;
        }


        // Get All ProductAttributes
        public async Task<IEnumerable<ProductAttributeValuesModel>> GetProductattributevalues()
        {
            return await _context.ProductAttributeValues.Select(c =>
                new ProductAttributeValuesModel
                {
                    
                    
                    


                }).ToListAsync();
        }

        // Get Single ProductAttribute
        public async Task<ProductAttributeValuesModel> GetProductattributevalue(int id)
        {
            var entity = await _context.ProductAttributeValues.FindAsync(id);

            if (entity == null)
                return null;

            return new ProductAttributeValuesModel
            {
                

            };
        }

        // Create new ProductAttributes
        public async Task CreateProductattributevalue(ProductAttributeValuesModel model)
        {
            try
            {
                var entity = new ProductAttributeValue
                {
                    ProductId = model.ProductId,
                    ProductAttributeId = model.ProductAttributeId,
                    Value = model.Value

                };
                _context.ProductAttributeValues.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        // Update ProductAttributes
        public async Task UpdateProductattributevalue(ProductAttributeValuesModel model)
        {
            var entity = await _context.ProductAttributeValues.SingleAsync(c => c.ProductAttributeId== model.ProductAttributeId);
            {
                

                _context.ProductAttributeValues.Add(entity);

                await _context.SaveChangesAsync();
            }
        }

        // Delete ProductAttributes
        public async Task DeleteProductattributevalue(int id)
        {
            var entity = await _context.ProductAttributeValues.SingleAsync(c => c.ProductAttributeId == id);
            _context.ProductAttributeValues.Remove(entity);

            await _context.SaveChangesAsync();

        }
    }
}
