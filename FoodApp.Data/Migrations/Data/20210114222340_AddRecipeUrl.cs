using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations.Data
{
    public partial class AddRecipeUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Recipes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Recipes");
        }
    }
}
