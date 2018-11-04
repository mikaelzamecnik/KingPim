using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPim.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 100, nullable: false),
                    PublishedStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributesValues",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    SingleAttributeId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributesValues", x => new { x.ProductID, x.SingleAttributeId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SingleAttributes",
                columns: table => new
                {
                    SingleAttributeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeGroupId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleAttributes", x => x.SingleAttributeId);
                    table.ForeignKey(
                        name: "FK_SingleAttributes_AttributeGroups_AttributeGroupId",
                        column: x => x.AttributeGroupId,
                        principalTable: "AttributeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubcategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubcategoryName = table.Column<string>(maxLength: 100, nullable: false),
                    CategoryID = table.Column<int>(nullable: true),
                    PublishedStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubcategoryID);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    PublishedStatus = table.Column<bool>(nullable: false),
                    SubCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "SubcategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubcategoryAttributeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    SubcategoryId = table.Column<int>(nullable: false),
                    AttributeGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcategoryAttributeGroups", x => new { x.SubcategoryId, x.AttributeGroupId });
                    table.UniqueConstraint("AK_SubcategoryAttributeGroups_AttributeGroupId_SubcategoryId", x => new { x.AttributeGroupId, x.SubcategoryId });
                    table.ForeignKey(
                        name: "FK_SubcategoryAttributeGroups_AttributeGroups_AttributeGroupId",
                        column: x => x.AttributeGroupId,
                        principalTable: "AttributeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubcategoryAttributeGroups_SubCategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "SubcategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SingleAttributeId = table.Column<int>(nullable: false),
                    AttributeGroupId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeTypes", x => new { x.SingleAttributeId, x.AttributeGroupId });
                    table.UniqueConstraint("AK_AttributeTypes_AttributeGroupId_SingleAttributeId", x => new { x.AttributeGroupId, x.SingleAttributeId });
                    table.ForeignKey(
                        name: "FK_AttributeTypes_AttributeGroups_AttributeGroupId",
                        column: x => x.AttributeGroupId,
                        principalTable: "AttributeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeTypes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeTypes_SingleAttributes_SingleAttributeId",
                        column: x => x.SingleAttributeId,
                        principalTable: "SingleAttributes",
                        principalColumn: "SingleAttributeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeTypeValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    AttributeId = table.Column<int>(nullable: false),
                    SingleAttributeId = table.Column<int>(nullable: true),
                    AttributeGroupId = table.Column<int>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeTypeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeTypeValues_AttributeGroups_AttributeGroupId",
                        column: x => x.AttributeGroupId,
                        principalTable: "AttributeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttributeTypeValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeTypeValues_SingleAttributes_SingleAttributeId",
                        column: x => x.SingleAttributeId,
                        principalTable: "SingleAttributes",
                        principalColumn: "SingleAttributeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTypes_ProductId",
                table: "AttributeTypes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTypeValues_AttributeGroupId",
                table: "AttributeTypeValues",
                column: "AttributeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTypeValues_ProductId",
                table: "AttributeTypeValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTypeValues_SingleAttributeId",
                table: "AttributeTypeValues",
                column: "SingleAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleAttributes_AttributeGroupId",
                table: "SingleAttributes",
                column: "AttributeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryID",
                table: "SubCategories",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeTypes");

            migrationBuilder.DropTable(
                name: "AttributeTypeValues");

            migrationBuilder.DropTable(
                name: "ProductAttributesValues");

            migrationBuilder.DropTable(
                name: "SubcategoryAttributeGroups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SingleAttributes");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "AttributeGroups");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
