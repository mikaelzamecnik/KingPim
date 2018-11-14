using System.Linq;
using System;
using KingPim.Domain.Entities;

namespace KingPim.Persistence
{

    public static class DataSeed
    {

        public static void FillIfEmpty(KingPimDbContext ctx)
        {
            if (!ctx.SingleAttributes.Any())
            {
                ctx.SingleAttributes.Add(new SingleAttribute{AttributeGroupId =1, Name="USB", Description="For connect"});
                ctx.SingleAttributes.Add(new SingleAttribute{AttributeGroupId =1, Name="HDMI" , Description="For view"});
                ctx.SingleAttributes.Add(new SingleAttribute{AttributeGroupId =1, Name="VGA", Description="For view"});
                ctx.SaveChanges();
            }
            if (!ctx.UserRoles.Any())
            {
                ctx.UserRoles.Add(new UserRole { Role = "Admin" });
                ctx.UserRoles.Add(new UserRole { Role = "Publisher" });
                ctx.UserRoles.Add(new UserRole { Role = "Editor" });
                ctx.SaveChanges();
            }
            if (!ctx.Categories.Any())
            {
                ctx.Categories.Add(new Category { Name = "Computers" });
                ctx.Categories.Add(new Category { Name = "Televisions" });
                ctx.SaveChanges();
            }
            if (!ctx.SubCategories.Any())
            {
                ctx.SubCategories.Add(new SubCategory { Name = "Laptop", CategoryId = 1 });
                ctx.SubCategories.Add(new SubCategory { Name = "Desktop", CategoryId =1 });
                ctx.SubCategories.Add(new SubCategory { Name = "Small", CategoryId = 2 });
                ctx.SubCategories.Add(new SubCategory { Name = "Large", CategoryId=2 });
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
                    SubCategoryId = 1,
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