using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupMark.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Label = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Specific = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Label);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    SupMarkUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.SupMarkUserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeLabel = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_TypeLabel",
                        column: x => x.TypeLabel,
                        principalTable: "ProductTypes",
                        principalColumn: "Label",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListUser",
                columns: table => new
                {
                    ListsId = table.Column<int>(type: "int", nullable: false),
                    UsersSupMarkUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListUser", x => new { x.ListsId, x.UsersSupMarkUserId });
                    table.ForeignKey(
                        name: "FK_ListUser_Lists_ListsId",
                        column: x => x.ListsId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListUser_Users_UsersSupMarkUserId",
                        column: x => x.UsersSupMarkUserId,
                        principalTable: "Users",
                        principalColumn: "SupMarkUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedBySupMarkUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RemovedBySupMarkUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Users_AddedBySupMarkUserId",
                        column: x => x.AddedBySupMarkUserId,
                        principalTable: "Users",
                        principalColumn: "SupMarkUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Users_RemovedBySupMarkUserId",
                        column: x => x.RemovedBySupMarkUserId,
                        principalTable: "Users",
                        principalColumn: "SupMarkUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_AddedBySupMarkUserId",
                table: "Items",
                column: "AddedBySupMarkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ListId",
                table: "Items",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RemovedBySupMarkUserId",
                table: "Items",
                column: "RemovedBySupMarkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListUser_UsersSupMarkUserId",
                table: "ListUser",
                column: "UsersSupMarkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeLabel",
                table: "Products",
                column: "TypeLabel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ListUser");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
