using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations.Data
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_QuantityTypes_QuantityTypeId",
                table: "RecipeIngredients");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityTypeId",
                table: "RecipeIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_QuantityTypes_QuantityTypeId",
                table: "RecipeIngredients",
                column: "QuantityTypeId",
                principalTable: "QuantityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_QuantityTypes_QuantityTypeId",
                table: "RecipeIngredients");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityTypeId",
                table: "RecipeIngredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_QuantityTypes_QuantityTypeId",
                table: "RecipeIngredients",
                column: "QuantityTypeId",
                principalTable: "QuantityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
