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
                var entity = await _context.Products.SingleOrDefaultAsync(c => c.ProductID == model.ProductID);


                entity.ProductName = model.ProductName;
                entity.DateUpdated = model.DateUpdated;
                entity.EditedBy = model.EditedBy;
                entity.Version = model.Version;
                entity.PublishedStatus = model.PublishedStatus;
                entity.SubCategory = model.SubCategory;

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