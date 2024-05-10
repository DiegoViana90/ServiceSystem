using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ServiceSystem.Migrations
{
    public partial class MigrationsAjustadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false), 
                    OrderItemType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    TableNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalValue = table.Column<double>(type: "REAL", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OrderItemType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderItemType = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemPrice = table.Column<double>(type: "REAL", nullable: false), 
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTables",
                columns: table => new
                {
                    RestaurantTableId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TableNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    InService = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTables", x => x.RestaurantTableId);
                    table.ForeignKey(
                        name: "FK_RestaurantTables_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTables_OrderId",
                table: "RestaurantTables",
                column: "OrderId");

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Name", "Price", "OrderItemType" },
                values: new object[] { "Hamburguer", 8.00m, 1 });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Name", "Price", "OrderItemType" },
                values: new object[] { "Pizza", 12.00m, 1 });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Name", "Price", "OrderItemType" },
                values: new object[] { "Juyce", 4.00m, 2 });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Name", "Price", "OrderItemType" },
                values: new object[] { "Soda", 2.00m, 2 });

            migrationBuilder.InsertData(
                table: "RestaurantTables",
                columns: new[] { "TableNumber", "InService" },
                values: new object[] { 1, false });

            migrationBuilder.InsertData(
                table: "RestaurantTables",
                columns: new[] { "TableNumber", "InService" },
                values: new object[] { 2, false });

            migrationBuilder.InsertData(
                table: "RestaurantTables",
                columns: new[] { "TableNumber", "InService" },
                values: new object[] { 3, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "RestaurantTables");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
