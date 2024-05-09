using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceSystem.Migrations
{
    public partial class OrderModelAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Done",
                table: "Orders",
                newName: "RestaurantTableId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedDate",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "OpenOrder",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderType",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MenuItemId",
                table: "Orders",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantTableId",
                table: "Orders",
                column: "RestaurantTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MenuItems_MenuItemId",
                table: "Orders",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_RestaurantTables_RestaurantTableId",
                table: "Orders",
                column: "RestaurantTableId",
                principalTable: "RestaurantTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MenuItems_MenuItemId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_RestaurantTables_RestaurantTableId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MenuItemId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RestaurantTableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClosedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OpenOrder",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "RestaurantTableId",
                table: "Orders",
                newName: "Done");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Orders",
                type: "TEXT",
                nullable: true);
        }
    }
}
