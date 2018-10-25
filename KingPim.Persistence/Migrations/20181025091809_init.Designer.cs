﻿// <auto-generated />
using System;
using KingPim.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KingPim.Persistence.Migrations
{
    [DbContext(typeof(KingPimDbContext))]
    [Migration("20181025091809_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KingPim.Domain.Entities.AssetMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AltTextName");

                    b.Property<int?>("AssetTypeId");

                    b.Property<string>("FilePath");

                    b.Property<int>("MediaTypeId");

                    b.Property<int>("ProductId");

                    b.Property<bool>("SetPrimary");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.HasIndex("ProductId");

                    b.ToTable("AssetMedias");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AssetTypes");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.AttributeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("SubCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("AttributeGroups");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.AttributeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DataType");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AttributeTypes");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("EditedBy");

                    b.Property<string>("Name");

                    b.Property<int>("ProductId");

                    b.Property<bool>("PublishedStatus");

                    b.Property<int>("SubCategoryId");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.ProductAttributesValues", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("AttributeId");

                    b.Property<string>("Value");

                    b.HasKey("ProductId", "AttributeId");

                    b.HasAlternateKey("AttributeId", "ProductId");

                    b.ToTable("ProductAttributesValues");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SingleAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeGroupId");

                    b.Property<int>("AttributeTypeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AttributeGroupId");

                    b.HasIndex("AttributeTypeId");

                    b.ToTable("SingleAttributes");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("KingPim.Domain.Entities.AssetMedia", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.AssetType", "AssetType")
                        .WithMany()
                        .HasForeignKey("AssetTypeId");

                    b.HasOne("KingPim.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingPim.Domain.Entities.AttributeGroup", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingPim.Domain.Entities.Product", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingPim.Domain.Entities.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingPim.Domain.Entities.SingleAttribute", b =>
                {
                    b.HasOne("KingPim.Domain.Entities.AttributeGroup", "AttributeGroup")
                        .WithMany()
                        .HasForeignKey("AttributeGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingPim.Domain.Entities.AttributeType", "AttributeType")
                        .WithMany()
                        .HasForeignKey("AttributeTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
