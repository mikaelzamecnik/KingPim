﻿// <auto-generated />
using System;
using KingPim.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KingPim.Persistence.Migrations
{
    [DbContext(typeof(KingPimDbContext))]
    partial class KingPimDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KingPim.Domain.Entities.AttributeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<string>("EditedBy");

                    b.Property<string>("Name");

                    b.Property<bool>("PublishedStatus");

                    b.Property<int?>("SubCategoryId");

                    b.Property<double>("Version");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("AttributeGroups");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<string>("EditedBy");

                    b.Property<string>("Name");

                    b.Property<bool>("PublishedStatus");

                    b.Property<double>("Version");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<string>("EditedBy");

                    b.Property<string>("Name");

                    b.Property<bool>("PublishedStatus");

                    b.Property<int?>("SubCategoryId");

                    b.Property<double>("Version");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.ProductAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AttributeGroupId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<string>("EditedBy");

                    b.Property<string>("Name");

                    b.Property<int>("ProductAttributeValueId");

                    b.Property<bool>("PublishedStatus");

                    b.Property<string>("Type");

                    b.Property<double>("Version");

                    b.HasKey("Id");

                    b.HasIndex("AttributeGroupId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.ProductAttributeValue", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("ProductAttributeId");

                    b.Property<string>("Value");

                    b.HasKey("ProductId", "ProductAttributeId");

                    b.HasAlternateKey("ProductAttributeId", "ProductId");

                    b.HasIndex("ProductAttributeId")
                        .IsUnique();

                    b.ToTable("ProductAttributeValues");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Description");

                    b.Property<string>("EditedBy");

                    b.Property<string>("Name");

                    b.Property<bool>("PublishedStatus");

                    b.Property<double>("Version");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SubcategoryAttributeGroup", b =>
                {
                    b.Property<int>("SubcategoryId");

                    b.Property<int>("AttributeGroupId");

                    b.HasKey("SubcategoryId", "AttributeGroupId");

                    b.HasAlternateKey("AttributeGroupId", "SubcategoryId");

                    b.ToTable("SubcategoryAttributeGroups");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int?>("UserRoleId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.AttributeGroup", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.Product", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.ProductAttribute", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.AttributeGroup", "AttributeGroup")
                        .WithMany()
                        .HasForeignKey("AttributeGroupId");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.ProductAttributeValue", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.ProductAttribute", "ProductAttribute")
                        .WithOne("ProductAttributeValues")
                        .HasForeignKey("KingPim.Domain.Entities.ProductAttributeValue", "ProductAttributeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingPim.Domain.Entities.Product", "Product")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SubCategory", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SubcategoryAttributeGroup", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.AttributeGroup", "AttributeGroup")
                        .WithMany("Subcategory")
                        .HasForeignKey("AttributeGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingPim.Domain.Entities.SubCategory", "SubCategory")
                        .WithMany("AttributeGroups")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingPim.Domain.Entities.User", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.UserRole", "UserRoles")
                        .WithMany()
                        .HasForeignKey("UserRoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
