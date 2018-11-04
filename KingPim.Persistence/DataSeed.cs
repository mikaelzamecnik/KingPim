using System.Linq;
using System;
using KingPim.Domain.Entities;

namespace KingPim.Persistence
{

    public static class DataSeed
    {

        public static void FillIfEmpty(KingPimDbContext ctx)
        {
            
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
                    Version = "v3.2",
                    SubCategoryId = 1,
                   
                });
                ctx.SaveChanges();
            }

        }

    }





}