using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectfoodie.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDayMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishMenu");

            migrationBuilder.AddColumn<int>(
                name: "DayMenuId",
                table: "Dishes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "DayMenu",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "DayMenu",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DayMenuId",
                table: "Dishes",
                column: "DayMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DayMenu_DayMenuId",
                table: "Dishes",
                column: "DayMenuId",
                principalTable: "DayMenu",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DayMenu_DayMenuId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_DayMenuId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DayMenuId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "date",
                table: "DayMenu");

            migrationBuilder.DropColumn(
                name: "type",
                table: "DayMenu");

            migrationBuilder.CreateTable(
                name: "DishMenu",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishMenu", x => new { x.DishesId, x.MenusId });
                    table.ForeignKey(
                        name: "FK_DishMenu_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishMenu_Menus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishMenu_MenusId",
                table: "DishMenu",
                column: "MenusId");
        }
    }
}
