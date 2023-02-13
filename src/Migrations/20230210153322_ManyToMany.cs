using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectfoodie.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishMenu_Dishes_DishId",
                table: "DishMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_DishMenu_Menus_MenuId",
                table: "DishMenu");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "DishMenu",
                newName: "MenusId");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "DishMenu",
                newName: "DishesId");

            migrationBuilder.RenameIndex(
                name: "IX_DishMenu_DishId",
                table: "DishMenu",
                newName: "IX_DishMenu_MenusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishMenu_Dishes_DishesId",
                table: "DishMenu",
                column: "DishesId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishMenu_Menus_MenusId",
                table: "DishMenu",
                column: "MenusId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishMenu_Dishes_DishesId",
                table: "DishMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_DishMenu_Menus_MenusId",
                table: "DishMenu");

            migrationBuilder.RenameColumn(
                name: "MenusId",
                table: "DishMenu",
                newName: "DishId");

            migrationBuilder.RenameColumn(
                name: "DishesId",
                table: "DishMenu",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_DishMenu_MenusId",
                table: "DishMenu",
                newName: "IX_DishMenu_DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishMenu_Dishes_DishId",
                table: "DishMenu",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishMenu_Menus_MenuId",
                table: "DishMenu",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
