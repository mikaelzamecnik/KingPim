using KingPim.Application.ProductService.Get;
using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Application.Helpers
{
    public static class ExportHelper
    {

        public static List<ProductGetAllModel> GetProducts(IEnumerable<Product> products)
        {
            var productVm = new List<ProductGetAllModel>();
            foreach (var product in products)
            {
                productVm.Add(new ProductGetAllModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    DateCreated = product.DateCreated,
                    DateUpdated = product.DateUpdated,
                    Version = product.Version,
                    PublishedStatus = product.PublishedStatus
                });
            }
            return productVm;

        }
    }
}
