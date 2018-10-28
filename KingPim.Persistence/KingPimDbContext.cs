

using KingPim.Domain.Entities;
using KingPim.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KingPim.Persistence
{

public class KingPimDbContext: IdentityDbContext<IdentityUser>
{

    public KingPimDbContext(DbContextOptions<KingPimDbContext> options):base(options) {}

    public DbSet<AttributeGroup> AttributeGroups{get;set;}
    public DbSet<AssetMedia> AssetMedias{get;set;}
    public DbSet<AssetType> AssetTypes{get;set;}
    public DbSet<AttributeType> AttributeTypes{get;set;}
    public DbSet<Category> Categories{get;set;}
    public DbSet<Product> Products{get;set;}
    public DbSet<SingleAttribute> SingleAttributes{get;set;}
    public DbSet<SubCategory> SubCategories{get;set;}
    public DbSet<ProductAttributesValues> ProductAttributesValues{get;set;}
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Editor> Editors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductAttributesValues>()
            .HasKey(c => new { c.ProductId, c.AttributeId });
    }

}
}