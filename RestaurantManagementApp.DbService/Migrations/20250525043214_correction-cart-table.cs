using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagementApp.DbService.Migrations
{
    /// <inheritdoc />
    public partial class correctioncarttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblAdmins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    HashedPassword = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblAdmins_TblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCustomers_TblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CustomerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCarts_TblCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "TblCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblCartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CartId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MenuItemId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCartItems_TblCarts_CartId",
                        column: x => x.CartId,
                        principalTable: "TblCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblCartItems_TblMenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "TblMenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TblAdmins_UserId",
                table: "TblAdmins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCartItems_CartId",
                table: "TblCartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCartItems_MenuItemId",
                table: "TblCartItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCarts_CustomerId",
                table: "TblCarts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCustomers_UserId",
                table: "TblCustomers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAdmins");

            migrationBuilder.DropTable(
                name: "TblCartItems");

            migrationBuilder.DropTable(
                name: "TblCarts");

            migrationBuilder.DropTable(
                name: "TblCustomers");

            migrationBuilder.DropTable(
                name: "TblUsers");
        }
    }
}
