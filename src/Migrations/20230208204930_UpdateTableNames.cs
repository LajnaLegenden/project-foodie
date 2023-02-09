using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectfoodie.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllergenDish_Allergens_AllergenId",
                table: "AllergenDish");

            migrationBuilder.DropForeignKey(
                name: "FK_AllergenDish_Dishes_DishId",
                table: "AllergenDish");

            migrationBuilder.DropForeignKey(
                name: "FK_AllergenIngredient_Allergens_AllergenId",
                table: "AllergenIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_AllergenIngredient_Ingredients_IngredientId",
                table: "AllergenIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Dishes_DishId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Orders_OrderId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientDish_Dishes_DishId",
                table: "IngredientDish");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientDish_Ingredients_IngredientId",
                table: "IngredientDish");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemOrder_OrderItem_OrderItemId",
                table: "OrderItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemOrder_Orders_OrderId",
                table: "OrderItemOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemOrder",
                table: "OrderItemOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientDish",
                table: "IngredientDish");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllergenIngredient",
                table: "AllergenIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllergenDish",
                table: "AllergenDish");

            migrationBuilder.RenameTable(
                name: "OrderItemOrder",
                newName: "OrderItemOrders");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "IngredientDish",
                newName: "IngredientDishes");

            migrationBuilder.RenameTable(
                name: "DishOrder",
                newName: "DishOrders");

            migrationBuilder.RenameTable(
                name: "AllergenIngredient",
                newName: "AllergenIngredients");

            migrationBuilder.RenameTable(
                name: "AllergenDish",
                newName: "AllergenDishes");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemOrder_OrderId",
                table: "OrderItemOrders",
                newName: "IX_OrderItemOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientDish_DishId",
                table: "IngredientDishes",
                newName: "IX_IngredientDishes_DishId");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrder_OrderId",
                table: "DishOrders",
                newName: "IX_DishOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_AllergenIngredient_IngredientId",
                table: "AllergenIngredients",
                newName: "IX_AllergenIngredients_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_AllergenDish_DishId",
                table: "AllergenDishes",
                newName: "IX_AllergenDishes_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemOrders",
                table: "OrderItemOrders",
                columns: new[] { "OrderItemId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientDishes",
                table: "IngredientDishes",
                columns: new[] { "IngredientId", "DishId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders",
                columns: new[] { "DishId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllergenIngredients",
                table: "AllergenIngredients",
                columns: new[] { "AllergenId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllergenDishes",
                table: "AllergenDishes",
                columns: new[] { "AllergenId", "DishId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AllergenDishes_Allergens_AllergenId",
                table: "AllergenDishes",
                column: "AllergenId",
                principalTable: "Allergens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllergenDishes_Dishes_DishId",
                table: "AllergenDishes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllergenIngredients_Allergens_AllergenId",
                table: "AllergenIngredients",
                column: "AllergenId",
                principalTable: "Allergens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllergenIngredients_Ingredients_IngredientId",
                table: "AllergenIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Dishes_DishId",
                table: "DishOrders",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Orders_OrderId",
                table: "DishOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientDishes_Dishes_DishId",
                table: "IngredientDishes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientDishes_Ingredients_IngredientId",
                table: "IngredientDishes",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemOrders_OrderItems_OrderItemId",
                table: "OrderItemOrders",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemOrders_Orders_OrderId",
                table: "OrderItemOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllergenDishes_Allergens_AllergenId",
                table: "AllergenDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_AllergenDishes_Dishes_DishId",
                table: "AllergenDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_AllergenIngredients_Allergens_AllergenId",
                table: "AllergenIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_AllergenIngredients_Ingredients_IngredientId",
                table: "AllergenIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Dishes_DishId",
                table: "DishOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Orders_OrderId",
                table: "DishOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientDishes_Dishes_DishId",
                table: "IngredientDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientDishes_Ingredients_IngredientId",
                table: "IngredientDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemOrders_OrderItems_OrderItemId",
                table: "OrderItemOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemOrders_Orders_OrderId",
                table: "OrderItemOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemOrders",
                table: "OrderItemOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientDishes",
                table: "IngredientDishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllergenIngredients",
                table: "AllergenIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllergenDishes",
                table: "AllergenDishes");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "OrderItemOrders",
                newName: "OrderItemOrder");

            migrationBuilder.RenameTable(
                name: "IngredientDishes",
                newName: "IngredientDish");

            migrationBuilder.RenameTable(
                name: "DishOrders",
                newName: "DishOrder");

            migrationBuilder.RenameTable(
                name: "AllergenIngredients",
                newName: "AllergenIngredient");

            migrationBuilder.RenameTable(
                name: "AllergenDishes",
                newName: "AllergenDish");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemOrders_OrderId",
                table: "OrderItemOrder",
                newName: "IX_OrderItemOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientDishes_DishId",
                table: "IngredientDish",
                newName: "IX_IngredientDish_DishId");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrders_OrderId",
                table: "DishOrder",
                newName: "IX_DishOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_AllergenIngredients_IngredientId",
                table: "AllergenIngredient",
                newName: "IX_AllergenIngredient_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_AllergenDishes_DishId",
                table: "AllergenDish",
                newName: "IX_AllergenDish_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemOrder",
                table: "OrderItemOrder",
                columns: new[] { "OrderItemId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientDish",
                table: "IngredientDish",
                columns: new[] { "IngredientId", "DishId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder",
                columns: new[] { "DishId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllergenIngredient",
                table: "AllergenIngredient",
                columns: new[] { "AllergenId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllergenDish",
                table: "AllergenDish",
                columns: new[] { "AllergenId", "DishId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AllergenDish_Allergens_AllergenId",
                table: "AllergenDish",
                column: "AllergenId",
                principalTable: "Allergens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllergenDish_Dishes_DishId",
                table: "AllergenDish",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllergenIngredient_Allergens_AllergenId",
                table: "AllergenIngredient",
                column: "AllergenId",
                principalTable: "Allergens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllergenIngredient_Ingredients_IngredientId",
                table: "AllergenIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Dishes_DishId",
                table: "DishOrder",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Orders_OrderId",
                table: "DishOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientDish_Dishes_DishId",
                table: "IngredientDish",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientDish_Ingredients_IngredientId",
                table: "IngredientDish",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemOrder_OrderItem_OrderItemId",
                table: "OrderItemOrder",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemOrder_Orders_OrderId",
                table: "OrderItemOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
