using System.Linq;
using System;
using KingPim.Domain.Entities;

namespace KingPim.Persistence{

public static class DataSeed{

public static void FillIfEmpty(KingPimDbContext ctx){
    /* if(!ctx.AssetMedias.Any()){
        ctx.AssetMedias.Add(new AssetMedia{})
    } */
    if(!ctx.Categories.Any()){
        ctx.Categories.Add(new Category{Name = "Computers"});
        ctx.Categories.Add(new Category{Name = "Televisions"});
        ctx.SaveChanges();
    }
    if(!ctx.SubCategories.Any()){
        ctx.SubCategories.Add(new SubCategory{Name = "Laptop"});
        ctx.SubCategories.Add(new SubCategory{Name = "Desktop"});
        ctx.SubCategories.Add(new SubCategory{Name = "Small"});
        ctx.SubCategories.Add(new SubCategory{Name = "Large"});
        ctx.SaveChanges();
    }
    if(!ctx.Products.Any()){
        ctx.Products.Add(new Product{Name = "Lenovo",CategoryId=1, SubCategoryId=1, DateCreated = DateTime.Now,
        DateUpdated = DateTime.Now, EditedBy = "Mike", Version = "v3.2", PublishedStatus = false});

        ctx.Products.Add(new Product{Name = "IBM",CategoryId = 1,SubCategoryId =1, DateCreated = DateTime.Now,
        DateUpdated = DateTime.Now, EditedBy = "Mike", Version = "v3.2", PublishedStatus = false});

        ctx.Products.Add(new Product{Name = "Sony",
            CategoryId = 2, SubCategoryId =2, DateCreated = DateTime.Now,
        DateUpdated = DateTime.Now, EditedBy = "Bert", Version = "v3.2", PublishedStatus = false});

        ctx.Products.Add(new Product{Name = "LG",
            CategoryId = 2, SubCategoryId =2, DateCreated = DateTime.Now,
        DateUpdated = DateTime.Now, EditedBy = "Bert", Version = "v3.2", PublishedStatus = false});
        ctx.SaveChanges();
    }


}

}





}