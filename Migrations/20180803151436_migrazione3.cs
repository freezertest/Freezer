using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeezeDotNet.Migrations
{
    public partial class migrazione3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Portion",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Food");

            migrationBuilder.CreateTable(
                name: "Portions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_PortionId",
                table: "Food",
                column: "PortionId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_TypeId",
                table: "Food",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Portions_PortionId",
                table: "Food",
                column: "PortionId",
                principalTable: "Portions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Types_TypeId",
                table: "Food",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Portions_PortionId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Types_TypeId",
                table: "Food");

            migrationBuilder.DropTable(
                name: "Portions");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Food_PortionId",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_TypeId",
                table: "Food");

            migrationBuilder.AddColumn<int>(
                name: "Portion",
                table: "Food",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Food",
                nullable: false,
                defaultValue: 0);
        }
    }
}
