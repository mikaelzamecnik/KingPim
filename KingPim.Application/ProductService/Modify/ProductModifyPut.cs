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
            var entity = await _context.Products.SingleAsync(c => c.Id == model.Id);
                {
                    entity.Id = model.Id;
                    entity.Name = model.Name;
                entity.DateUpdated = model.DateUpdated;
                entity.EditedBy = model.EditedBy;
                entity.Version = model.Version;
                entity.PublishedStatus = model.PublishedStatus;
                entity.SubCategoryId = model.SubCategoryId;

                     _context.Products.Add(entity);

                await _context.SaveChangesAsync();
                }
               
        }
    }
}