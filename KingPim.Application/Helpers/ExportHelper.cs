using KingPim.Application.CategoryService.Get;
using KingPim.Application.ProductService.Get;
using KingPim.Application.SubCategoryService.Get;
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
        public static List<CategoryGetAllModel> GetCategories(IEnumerable<Category> categories)
        {
            var categoryVm = new List<CategoryGetAllModel>();
            foreach (var category in categories)
            {
                categoryVm.Add(new CategoryGetAllModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    DateCreated = category.DateCreated,
                    DateUpdated = category.DateUpdated,
                    Version = category.Version,
                    PublishedStatus = category.PublishedStatus
                });
            }
            return categoryVm;

        }
        public static List<SubCategoryGetAllModel> GetSubCategories(IEnumerable<SubCategory> subcategories)
        {
            var subcategoryVm = new List<SubCategoryGetAllModel>();
            foreach (var subcategory in subcategories)
            {
                subcategoryVm.Add(new SubCategoryGetAllModel
                {
                    Id = subcategory.Id,
                    Name = subcategory.Name,
                    DateCreated = subcategory.DateCreated,
                    DateUpdated = subcategory.DateUpdated,
                    Version = subcategory.Version,
                    PublishedStatus = subcategory.PublishedStatus
                });
            }
            return subcategoryVm;

        }
    }
}
