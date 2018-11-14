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
            try
            {
                var entity =  await _context.Products.SingleOrDefaultAsync(c => c.Id == model.Id);


                entity.Name = model.Name;
                entity.DateUpdated = model.DateUpdated;
                entity.EditedBy = model.EditedBy;
                entity.Description = model.Description;
                entity.Version = model.Version;
                entity.PublishedStatus = model.PublishedStatus;
                entity.SubCategory = model.SubCategory;
                entity.ProductAttributeValues = model.ProductAttributeValues;

                _context.Products.Update(entity);

                await _context.SaveChangesAsync();
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}