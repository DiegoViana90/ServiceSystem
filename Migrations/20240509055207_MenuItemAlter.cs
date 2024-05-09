using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceSystem.Migrations
{
    public partial class MenuItemAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "MenuItems",
                newName: "MenuType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuType",
                table: "MenuItems",
                newName: "Type");
        }
    }
}
