using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagementApp.DbService.Migrations
{
    /// <inheritdoc />
    public partial class RemoveKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblMenuItemCustomizeOptions_TblMenuItems_MenuItemId1",
                table: "TblMenuItemCustomizeOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblMenuItemCustomizeOptions",
                table: "TblMenuItemCustomizeOptions");

            migrationBuilder.DropIndex(
                name: "IX_TblMenuItemCustomizeOptions_MenuItemId1",
                table: "TblMenuItemCustomizeOptions");

            migrationBuilder.RenameColumn(
                name: "MenuItemId1",
                table: "TblMenuItemCustomizeOptions",
                newName: "MenuItemCustomizeOptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblMenuItemCustomizeOptions",
                table: "TblMenuItemCustomizeOptions",
                column: "MenuItemCustomizeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMenuItemCustomizeOptions_MenuItemId",
                table: "TblMenuItemCustomizeOptions",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblMenuItemCustomizeOptions_TblMenuItems_MenuItemId",
                table: "TblMenuItemCustomizeOptions",
                column: "MenuItemId",
                principalTable: "TblMenuItems",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblMenuItemCustomizeOptions_TblMenuItems_MenuItemId",
                table: "TblMenuItemCustomizeOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblMenuItemCustomizeOptions",
                table: "TblMenuItemCustomizeOptions");

            migrationBuilder.DropIndex(
                name: "IX_TblMenuItemCustomizeOptions_MenuItemId",
                table: "TblMenuItemCustomizeOptions");

            migrationBuilder.RenameColumn(
                name: "MenuItemCustomizeOptionId",
                table: "TblMenuItemCustomizeOptions",
                newName: "MenuItemId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblMenuItemCustomizeOptions",
                table: "TblMenuItemCustomizeOptions",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMenuItemCustomizeOptions_MenuItemId1",
                table: "TblMenuItemCustomizeOptions",
                column: "MenuItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TblMenuItemCustomizeOptions_TblMenuItems_MenuItemId1",
                table: "TblMenuItemCustomizeOptions",
                column: "MenuItemId1",
                principalTable: "TblMenuItems",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
