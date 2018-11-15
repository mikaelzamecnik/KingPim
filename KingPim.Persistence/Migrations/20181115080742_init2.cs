using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPim.Persistence.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubcategoryAttributeGroups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SubcategoryAttributeGroups",
                nullable: false,
                defaultValue: 0);
        }
    }
}
