using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPim.Persistence.Migrations
{
    public partial class attg_added_to_attop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttributeGroupId",
                table: "AttributeOptionLists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptionLists_AttributeGroupId",
                table: "AttributeOptionLists",
                column: "AttributeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeOptionLists_AttributeGroups_AttributeGroupId",
                table: "AttributeOptionLists",
                column: "AttributeGroupId",
                principalTable: "AttributeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeOptionLists_AttributeGroups_AttributeGroupId",
                table: "AttributeOptionLists");

            migrationBuilder.DropIndex(
                name: "IX_AttributeOptionLists_AttributeGroupId",
                table: "AttributeOptionLists");

            migrationBuilder.DropColumn(
                name: "AttributeGroupId",
                table: "AttributeOptionLists");
        }
    }
}
