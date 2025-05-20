using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagementApp.DbService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoryName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCategories", x => x.CategoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblCustomizeOptions",
                columns: table => new
                {
                    CustomizeOptionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCustomizeOptions", x => x.CustomizeOptionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblMenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MenuItemName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMenuItems", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_TblMenuItems_TblCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TblCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblMenuItemCustomizeOptions",
                columns: table => new
                {
                    MenuItemId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CustomizeOptionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MenuItemId1 = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMenuItemCustomizeOptions", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_TblMenuItemCustomizeOptions_TblCustomizeOptions_CustomizeOpt~",
                        column: x => x.CustomizeOptionId,
                        principalTable: "TblCustomizeOptions",
                        principalColumn: "CustomizeOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblMenuItemCustomizeOptions_TblMenuItems_MenuItemId1",
                        column: x => x.MenuItemId1,
                        principalTable: "TblMenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TblMenuItemCustomizeOptions_CustomizeOptionId",
                table: "TblMenuItemCustomizeOptions",
                column: "CustomizeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMenuItemCustomizeOptions_MenuItemId1",
                table: "TblMenuItemCustomizeOptions",
                column: "MenuItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_TblMenuItems_CategoryId",
                table: "TblMenuItems",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblMenuItemCustomizeOptions");

            migrationBuilder.DropTable(
                name: "TblCustomizeOptions");

            migrationBuilder.DropTable(
                name: "TblMenuItems");

            migrationBuilder.DropTable(
                name: "TblCategories");
        }
    }
}
