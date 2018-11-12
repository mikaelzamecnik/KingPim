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

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AttributeGroups");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.AttributeValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductAttributeId");

                    b.Property<int>("ProductId");

                    b.Property<int>("SingleAttributeId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SingleAttributeId");

                    b.ToTable("AttributeValue");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<bool>("PublishedStatus");

                    b.HasKey("Id");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CatalogId");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("PublishedStatus");

                    b.HasKey("CategoryID");

                    b.HasIndex("CatalogId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CatalogId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("EditedBy");

                    b.Property<string>("ProductName");

                    b.Property<bool>("PublishedStatus");

                    b.Property<int>("SubCategoryId");

                    b.Property<int>("Version");

                    b.HasKey("ProductID");

                    b.HasIndex("CatalogId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SingleAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttValueEnum");

                    b.Property<int>("AttributeGroupId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AttributeGroupId");

                    b.ToTable("SingleAttributes");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SubCategory", b =>
                {
                    b.Property<int>("SubcategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CatalogId");

                    b.Property<int?>("CategoryID");

                    b.Property<bool>("PublishedStatus");

                    b.Property<string>("SubcategoryName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("SubcategoryID");

                    b.HasIndex("CatalogId");

                    b.HasIndex("CategoryID");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SubcategoryAttributeGroup", b =>
                {
                    b.Property<int>("SubcategoryId");

                    b.Property<int>("AttributeGroupId");

                    b.Property<int>("Id");

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

                    b.Property<int>("RoleId");

                    b.Property<int?>("UserRolesId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("UserRolesId");

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

            modelBuilder.Entity("KingPim.Domain.Entities.AttributeValue", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.Product", "Product")
                        .WithMany("AttributeValue")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingPim.Domain.Entities.SingleAttribute", "SingleAttribute")
                        .WithMany()
                        .HasForeignKey("SingleAttributeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingPim.Domain.Entities.Category", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.Catalog", "Catalog")
                        .WithMany("Categories")
                        .HasForeignKey("CatalogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingPim.Domain.Entities.Product", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.Catalog")
                        .WithMany("Products")
                        .HasForeignKey("CatalogId");

                    b.HasOne("KingPim.Domain.Entities.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SingleAttribute", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.AttributeGroup", "AttributeGroup")
                        .WithMany("SingleAttribute")
                        .HasForeignKey("AttributeGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SubCategory", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.Catalog")
                        .WithMany("SubCategories")
                        .HasForeignKey("CatalogId");

                    b.HasOne("KingPim.Domain.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SubcategoryAttributeGroup", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.AttributeGroup", "AttributeGroup")
                        .WithMany("SubcategoryAttributeGroups")
                        .HasForeignKey("AttributeGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingPim.Domain.Entities.SubCategory", "SubCategory")
                        .WithMany("SubcategoryAttributeGroups")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingPim.Domain.Entities.User", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.UserRole", "UserRoles")
                        .WithMany()
                        .HasForeignKey("UserRolesId");
                });
#pragma warning restore 612, 618
        }
    }
}
