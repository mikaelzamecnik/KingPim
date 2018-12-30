using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPim.Persistence.Migrations
{
    public partial class added_attributeoptionlist_to_productattribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttributeOptionListId",
                table: "ProductAttributes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttributeOptionsListId",
                table: "ProductAttributes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_AttributeOptionListId",
                table: "ProductAttributes",
                column: "AttributeOptionListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_AttributeOptionLists_AttributeOptionListId",
                table: "ProductAttributes",
                column: "AttributeOptionListId",
                principalTable: "AttributeOptionLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_AttributeOptionLists_AttributeOptionListId",
                table: "ProductAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_AttributeOptionListId",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "AttributeOptionListId",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "AttributeOptionsListId",
                table: "ProductAttributes");
        }
    }
}
