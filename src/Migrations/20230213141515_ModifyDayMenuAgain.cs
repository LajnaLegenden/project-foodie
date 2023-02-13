using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectfoodie.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDayMenuAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DayMenuDish",
                columns: table => new
                {
                    dayMenusId = table.Column<int>(type: "INTEGER", nullable: false),
                    dishesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayMenuDish", x => new { x.dayMenusId, x.dishesId });
                    table.ForeignKey(
                        name: "FK_DayMenuDish_DayMenu_dayMenusId",
                        column: x => x.dayMenusId,
                        principalTable: "DayMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayMenuDish_Dishes_dishesId",
                        column: x => x.dishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayMenuDish_dishesId",
                table: "DayMenuDish",
                column: "dishesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayMenuDish");

            migrationBuilder.AddColumn<int>(
                name: "DayMenuId",
                table: "Dishes",
                type: "INTEGER",
                nullable: true);

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
    }
}
