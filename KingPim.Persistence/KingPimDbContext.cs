using KingPim.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace KingPim.Persistence
{

public class KingPimDbContext: DbContext
{
        public KingPimDbContext()
        {
        }

        public KingPimDbContext(DbContextOptions<KingPimDbContext> options):base(options) {}

        public DbSet<AttributeGroup> AttributeGroups{get;set;}
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<AttributeOptionList> AttributeOptionLists { get; set; }
        public DbSet<AttributeOptionListValue> AttributeOptionListValues { get; set; }
        public DbSet<Category> Categories{get;set;}
        public DbSet<Product> Products{get;set;}
        public DbSet<SubCategory> SubCategories{get;set;}
        public DbSet<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}