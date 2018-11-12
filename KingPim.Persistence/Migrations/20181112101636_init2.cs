using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPim.Persistence.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValue_SingleAttributes_SingleAttributeId",
                table: "AttributeValue");

            migrationBuilder.AlterColumn<int>(
                name: "SingleAttributeId",
                table: "AttributeValue",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValue_SingleAttributes_SingleAttributeId",
                table: "AttributeValue",
                column: "SingleAttributeId",
                principalTable: "SingleAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValue_SingleAttributes_SingleAttributeId",
                table: "AttributeValue");

            migrationBuilder.AlterColumn<int>(
                name: "SingleAttributeId",
                table: "AttributeValue",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValue_SingleAttributes_SingleAttributeId",
                table: "AttributeValue",
                column: "SingleAttributeId",
                principalTable: "SingleAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
