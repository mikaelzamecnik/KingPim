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
                ctx.SaveChanges();
            }
            if (!ctx.AttributeGroups.Any())
            {
                ctx.AttributeGroups.Add(new AttributeGroup
                {
                    Name = "Ports",
                    Description = "For connect"
                });
                ctx.SaveChanges();
            }




        }

    }





}