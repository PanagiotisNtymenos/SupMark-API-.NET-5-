using Microsoft.EntityFrameworkCore.Migrations;

namespace SupMark.Infrastructure.Migrations
{
    public partial class DataInJSON : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ListsJSON",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemsJSON",
                table: "Lists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersJSON",
                table: "Lists",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListsJSON",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ItemsJSON",
                table: "Lists");

            migrationBuilder.DropColumn(
                name: "UsersJSON",
                table: "Lists");
        }
    }
}
