using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations.Data
{
    public partial class ChangeRecipeStepPlural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeStep_Recipes_RecipeId",
                table: "RecipeStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeStep",
                table: "RecipeStep");

            migrationBuilder.RenameTable(
                name: "RecipeStep",
                newName: "RecipeSteps");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeStep_RecipeId",
                table: "RecipeSteps",
                newName: "IX_RecipeSteps_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeSteps",
                table: "RecipeSteps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeSteps",
                table: "RecipeSteps");

            migrationBuilder.RenameTable(
                name: "RecipeSteps",
                newName: "RecipeStep");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeSteps_RecipeId",
                table: "RecipeStep",
                newName: "IX_RecipeStep_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeStep",
                table: "RecipeStep",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeStep_Recipes_RecipeId",
                table: "RecipeStep",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
