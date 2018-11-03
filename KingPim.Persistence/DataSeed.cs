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

                    SubCategoryId = 1,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    EditedBy = "Mike",
                    Version = "v3.2",
                    PublishedStatus = false
                });

                ctx.Products.Add(new Product
                {
                    ProductName = "IBM",

                    SubCategoryId = 2,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    EditedBy = "Mike",
                    Version = "v3.2",
                    PublishedStatus = false
                });

                ctx.Products.Add(new Product
                {
                    ProductName = "Sony",

                    SubCategoryId = 3,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    EditedBy = "Bert",
                    Version = "v3.2",
                    PublishedStatus = false
                });

                ctx.Products.Add(new Product
                {
                    ProductName = "LG",

                    SubCategoryId = 4,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    EditedBy = "Bert",
                    Version = "v3.2",
                    PublishedStatus = false
                });
                ctx.SaveChanges();
            }


        }

    }





}