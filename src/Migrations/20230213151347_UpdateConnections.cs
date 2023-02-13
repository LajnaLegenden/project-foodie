using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectfoodie.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishOrder");

            migrationBuilder.DropTable(
                name: "OrderOrderItem");

            migrationBuilder.DropColumn(
                name: "orderItemId",
                table: "OrderItem");

            migrationBuilder.AlterColumn<int>(
                name: "menuId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "orderId",
                table: "OrderItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "dishId",
                table: "OrderItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_menuId",
                table: "Orders",
                column: "menuId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_dishId",
                table: "OrderItem",
                column: "dishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_orderId",
                table: "OrderItem",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Dishes_dishId",
                table: "OrderItem",
                column: "dishId",
                principalTable: "Dishes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_orderId",
                table: "OrderItem",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Menus_menuId",
                table: "Orders",
                column: "menuId",
                principalTable: "Menus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Dishes_dishId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_orderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Menus_menuId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_menuId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_dishId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_orderId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "dishId",
                table: "OrderItem");

            migrationBuilder.AlterColumn<int>(
                name: "menuId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "orderId",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orderItemId",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DishOrder",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishOrder", x => new { x.DishesId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_DishOrder_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderOrderItem",
                columns: table => new
                {
                    OrderItemsId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrderItem", x => new { x.OrderItemsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderOrderItem_OrderItem_OrderItemsId",
                        column: x => x.OrderItemsId,
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrderItem_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DishOrder_OrdersId",
                table: "DishOrder",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrderItem_OrdersId",
                table: "OrderOrderItem",
                column: "OrdersId");
        }
    }
}
