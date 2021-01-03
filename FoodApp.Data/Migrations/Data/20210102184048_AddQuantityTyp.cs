using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations.Data
{
    public partial class AddQuantityTyp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityType",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "QuantityType",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "QuantityTypeId",
                table: "RecipeIngredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityTypeId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuantityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_QuantityTypeId",
                table: "RecipeIngredients",
                column: "QuantityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_QuantityTypeId",
                table: "Foods",
                column: "QuantityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_QuantityTypes_QuantityTypeId",
                table: "Foods",
                column: "QuantityTypeId",
                principalTable: "QuantityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_QuantityTypes_QuantityTypeId",
                table: "RecipeIngredients",
                column: "QuantityTypeId",
                principalTable: "QuantityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_QuantityTypes_QuantityTypeId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_QuantityTypes_QuantityTypeId",
                table: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "QuantityTypes");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredients_QuantityTypeId",
                table: "RecipeIngredients");

            migrationBuilder.DropIndex(
                name: "IX_Foods_QuantityTypeId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "QuantityTypeId",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "QuantityTypeId",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "QuantityType",
                table: "RecipeIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityType",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
