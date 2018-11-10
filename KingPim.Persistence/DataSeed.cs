using System.Linq;
using System;
using KingPim.Domain.Entities;
using AutoMapper;

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
                ctx.Categories.Add(new Category { CategoryName = "Computers" });
                ctx.Categories.Add(new Category { CategoryName = "Televisions" });
                ctx.SaveChanges();
            }
            if (!ctx.SubCategories.Any())
            {
                ctx.SubCategories.Add(new SubCategory { SubcategoryName = "Laptop", CategoryID = 1 });
                ctx.SubCategories.Add(new SubCategory { SubcategoryName = "Desktop", CategoryID =1 });
                ctx.SubCategories.Add(new SubCategory { SubcategoryName = "Small", CategoryID = 2 });
                ctx.SubCategories.Add(new SubCategory { SubcategoryName = "Large", CategoryID=2 });
                ctx.SaveChanges();
            }
            if (!ctx.Products.Any())
            {
                ctx.Products.Add(new Product
                {
                    ProductName = "Lenovo",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    EditedBy = "Mike",
                    Version = 1,
                    SubCategoryId = 1,
                });
                ctx.SaveChanges();
            }
            if (!ctx.AttributeGroups.Any())
            {
                ctx.AttributeGroups.Add(new AttributeGroup
                {
                    Name = "Ports",
                });
                ctx.SaveChanges();
            }

        }

    }





}