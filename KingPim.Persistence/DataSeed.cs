using System.Linq;
using System;
using KingPim.Domain.Entities;

namespace KingPim.Persistence
{

    public static class DataSeed
    {

        public static void FillIfEmpty(KingPimDbContext ctx)
        {

            if (!ctx.UserRoles.Any())
            {
                ctx.UserRoles.Add(new UserRole { Role = "Admin" });
                ctx.UserRoles.Add(new UserRole { Role = "Publisher" });
                ctx.UserRoles.Add(new UserRole { Role = "Editor" });
                ctx.SaveChanges();
            }
            if (!ctx.Categories.Any())
            {
                ctx.Categories.Add(new Category { Name = "Televisions" });
                ctx.Categories.Add(new Category { Name = "Computers" });
                ctx.SaveChanges();
            }
            if (!ctx.SubCategories.Any())
            {
                ctx.SubCategories.Add(new SubCategory { Name = "OLED", CategoryId = 1 });
                ctx.SubCategories.Add(new SubCategory { Name = "LED", CategoryId =1 });
                ctx.SubCategories.Add(new SubCategory { Name = "Laptops", CategoryId = 2 });
                ctx.SubCategories.Add(new SubCategory { Name = "Tablets", CategoryId=2 });
                ctx.SaveChanges();
            }
            if (!ctx.Products.Any())
            {
                ctx.Products.Add(new Product
                {
                    Name = "Lenovo",
                    Description = "Some product",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    EditedBy = "Mike",
                    Version = 1,
                    SubCategoryId = 3,
                });
                ctx.Products.Add(new Product
                {
                    Name = "Samsung",
                    Description = "Some product",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    EditedBy = "Sven",
                    Version = 1,
                    SubCategoryId = 2,
                    
                });
                ctx.SaveChanges();
            }
            if (!ctx.AttributeGroups.Any())
            {
                ctx.AttributeGroups.Add(new AttributeGroup { Name = "Ports", Description = "For connect", SubCategoryId = 3 });
                ctx.AttributeGroups.Add(new AttributeGroup { Name = "Dimensions", Description = "Size", SubCategoryId = 4 });

                ctx.SaveChanges();
            }
            if (!ctx.ProductAttributes.Any())
            {
                ctx.ProductAttributes.Add(new ProductAttribute { Name = "Usb", Description = "For connect", Type = "text", AttributeGroupId = 1});
                ctx.ProductAttributes.Add(new ProductAttribute { Name = "Width", Description = "Size", Type = "number", AttributeGroupId = 2 });
                ctx.ProductAttributes.Add(new ProductAttribute { Name = "Height", Description = "Size", Type = "yesno", AttributeGroupId = 2 });

                ctx.SaveChanges();
            }
            if (!ctx.ProductAttributeValues.Any())
            {
                ctx.ProductAttributeValues.Add(new ProductAttributeValue { Value = "Usb30", ProductAttributeId = 1, ProductId = 1 });
                ctx.ProductAttributeValues.Add(new ProductAttributeValue { Value = "500", ProductAttributeId = 2, ProductId = 1 });
                ctx.ProductAttributeValues.Add(new ProductAttributeValue { Value = "Yes", ProductAttributeId = 3, ProductId = 1 });
                ctx.ProductAttributeValues.Add(new ProductAttributeValue { Value = "Usb30", ProductAttributeId = 1, ProductId = 2 });
                ctx.ProductAttributeValues.Add(new ProductAttributeValue { Value = "500", ProductAttributeId = 2, ProductId = 2 });
                ctx.ProductAttributeValues.Add(new ProductAttributeValue { Value = "Yes", ProductAttributeId = 3, ProductId = 2 });

                ctx.SaveChanges();
            }




        }

    }





}