using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Migrations
{
    public partial class migrazione4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drawer_Freezers_FreezerId",
                table: "Drawer");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Drawer_DrawerId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Portions_PortionId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Types_TypeId",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drawer",
                table: "Drawer");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Foods");

            migrationBuilder.RenameTable(
                name: "Drawer",
                newName: "Drawers");

            migrationBuilder.RenameIndex(
                name: "IX_Food_TypeId",
                table: "Foods",
                newName: "IX_Foods_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_PortionId",
                table: "Foods",
                newName: "IX_Foods_PortionId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_DrawerId",
                table: "Foods",
                newName: "IX_Foods_DrawerId");

            migrationBuilder.RenameIndex(
                name: "IX_Drawer_FreezerId",
                table: "Drawers",
                newName: "IX_Drawers_FreezerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drawers",
                table: "Drawers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drawers_Freezers_FreezerId",
                table: "Drawers",
                column: "FreezerId",
                principalTable: "Freezers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Drawers_DrawerId",
                table: "Foods",
                column: "DrawerId",
                principalTable: "Drawers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Portions_PortionId",
                table: "Foods",
                column: "PortionId",
                principalTable: "Portions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Types_TypeId",
                table: "Foods",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drawers_Freezers_FreezerId",
                table: "Drawers");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Drawers_DrawerId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Portions_PortionId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Types_TypeId",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drawers",
                table: "Drawers");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food");

            migrationBuilder.RenameTable(
                name: "Drawers",
                newName: "Drawer");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_TypeId",
                table: "Food",
                newName: "IX_Food_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_PortionId",
                table: "Food",
                newName: "IX_Food_PortionId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_DrawerId",
                table: "Food",
                newName: "IX_Food_DrawerId");

            migrationBuilder.RenameIndex(
                name: "IX_Drawers_FreezerId",
                table: "Drawer",
                newName: "IX_Drawer_FreezerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drawer",
                table: "Drawer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drawer_Freezers_FreezerId",
                table: "Drawer",
                column: "FreezerId",
                principalTable: "Freezers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Drawer_DrawerId",
                table: "Food",
                column: "DrawerId",
                principalTable: "Drawer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
