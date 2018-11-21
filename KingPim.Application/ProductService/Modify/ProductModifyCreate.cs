using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;
using KingPim.Application.ProductAttributeValueService;

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

                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
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
        public void SaveProductAttributeValue(ProductAttributeValueModel model)
        {
            if (model.Id == 0)     // Add
            {
                var row = _context.ProductAttributeValues.FirstOrDefault(x => x.SingleAttributeId.Equals(model.SingleAttributeId) && x.ProductId.Equals(model.ProductId));
                if (row == null)
                {
                    var productAttributeValue = new ProductAttributeValue
                    {
                        Value = model.Value,
                        SingleAttributeId = model.SingleAttributeId,
                        ProductId = model.ProductId
                    };
                    _context.ProductAttributeValues.Add(productAttributeValue);
                }
                else
                {
                    _context.ProductAttributeValues.Remove(row);
                    _context.SaveChanges();
                    var productAttributeValue = new ProductAttributeValue
                    {
                        Value = model.Value,
                        SingleAttributeId = model.SingleAttributeId,
                        ProductId = model.ProductId
                    };
                    _context.ProductAttributeValues.Add(productAttributeValue);
                }
            }
            _context.SaveChanges();
        }
    }
}