using KingPim.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace KingPim.Persistence
{

public class KingPimDbContext: DbContext
{
        public KingPimDbContext(DbContextOptions<KingPimDbContext> options):base(options) {}
        public DbSet<AttributeGroup> AttributeGroups{get;set;}
        public DbSet<SingleAttribute> SingleAttributes { get; set; }
        public DbSet<Category> Categories{get;set;}
        public DbSet<Product> Products{get;set;}
        public DbSet<SubCategory> SubCategories{get;set;}
        public DbSet<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<SubcategoryAttributeGroup>()
            .HasKey(x => new { x.AttributeGroupId, x.SubCategoryId });

            modelBuilder.Entity<ProductAttributeValue>()
            .HasKey(x => new { x.SingleAttributeId, x.ProductId });

            modelBuilder.Entity<ProductAttributeValue>()
            .HasOne(bc => bc.SingleAttribute)
            .WithMany(b => b.ProductAttributeValues)
            .HasForeignKey(bc => bc.SingleAttributeId);

            modelBuilder.Entity<ProductAttributeValue>()
            .HasOne(bc => bc.Product)
            .WithMany(b => b.ProductAttributeValues)
            .HasForeignKey(bc => bc.ProductId);
        }
}
}