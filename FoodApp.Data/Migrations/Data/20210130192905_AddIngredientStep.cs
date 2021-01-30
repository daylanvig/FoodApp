using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations.Data
{
    public partial class AddIngredientStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Foods_FoodId",
                table: "RecipeIngredients");

            migrationBuilder.CreateTable(
                name: "RecipeStep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    StepNumber = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeStep_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeStep_RecipeId",
                table: "RecipeStep",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Foods_FoodId",
                table: "RecipeIngredients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Foods_FoodId",
                table: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeStep");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Foods_FoodId",
                table: "RecipeIngredients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
