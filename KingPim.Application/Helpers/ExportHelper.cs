using KingPim.Application.Repositories.Models;
using KingPim.Domain.Entities;
using System.Collections.Generic;


namespace KingPim.Application.Helpers
{
    public static class ExportHelper
    {

        public static List<ProductModel> GetProducts(IEnumerable<Product> products)
        {
            var productVm = new List<ProductModel>();
            foreach (var product in products)
            {
                productVm.Add(new ProductModel
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
        public static List<CategoryModel> GetCategories(IEnumerable<Category> categories)
        {
            var categoryVm = new List<CategoryModel>();
            foreach (var category in categories)
            {
                categoryVm.Add(new CategoryModel
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
        public static List<SubCategoryModel> GetSubcategories(IEnumerable<SubCategory> subcategories)
        {
            var subcategoryVm = new List<SubCategoryModel>();
            foreach (var subcategory in subcategories)
            {
                subcategoryVm.Add(new SubCategoryModel
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
