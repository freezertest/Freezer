using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeezeDotNet.Migrations
{
    public partial class migrazione2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortionId",
                table: "Food",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Food",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PortionId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Food");
        }
    }
}
