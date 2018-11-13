using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.ProductService.Modify
{
    public class ProductModifyCreate : IProductModifyCreate
    {
        public readonly KingPimDbContext _context;

        public ProductModifyCreate(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(ProductModifyCreateModel model)
        {
            try
            {
                var entity = new Product
                {

                    ProductID = model.ProductID,
                    ProductName = model.ProductName,
                    DateCreated = model.DateCreated,
                    EditedBy = model.EditedBy,
                    Version = model.Version,
                    PublishedStatus = model.PublishedStatus,
                    SubCategoryId = model.SubCategoryId,
                    SubCategory = model.SubCategory

                };
                _context.Products.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (System.Exception e)
            {

                throw e;
            }

        }
    }
}