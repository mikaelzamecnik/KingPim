using KingPim.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace KingPim.Persistence
{

public class KingPimDbContext: DbContext
{
        public KingPimDbContext(DbContextOptions<KingPimDbContext> options):base(options) {}
        public DbSet<AttributeGroup> AttributeGroups{get;set;}
        public DbSet<AttributeType> AttributeTypes{get;set;}
        public DbSet<AttributeTypeValue> AttributeTypeValues { get; set; }
        public DbSet<SingleAttribute> SingleAttributes { get; set; }
        public DbSet<Category> Categories{get;set;}
        public DbSet<Product> Products{get;set;}
        public DbSet<ProductAttributesValue> ProductAttributesValues { get; set; }
        public DbSet<SubCategory> SubCategories{get;set;}
        public DbSet<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductAttributesValue>()
            .HasKey(c => new { c.ProductID, c.SingleAttributeId });
            modelBuilder.Entity<SubcategoryAttributeGroup>()
            .HasKey(c => new { c.SubcategoryId, c.AttributeGroupId });
            modelBuilder.Entity<AttributeType>()
            .HasKey(c => new { c.SingleAttributeId, c.AttributeGroupId });
           // modelBuilder.Entity<SingleAttribute>()
           //.HasKey(c => new { c.SingleAttributeId, c.ProductId });
        }

}
}