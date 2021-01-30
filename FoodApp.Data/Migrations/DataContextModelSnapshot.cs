﻿// <auto-generated />
using System;
using FoodApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodApp.Data.Migrations.Data
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("FoodApp.Core.Domain.Foods.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("AmountOnHand")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("LastModifiedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4");

                    b.Property<int?>("QuantityTypeId")
                        .HasColumnType("int");

                    b.Property<string>("_applicationUserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("QuantityTypeId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FoodApp.Core.Domain.Foods.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("FoodApp.Core.Domain.Foods.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("QuantityTypeId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("QuantityTypeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("FoodApp.Core.Domain.QuantityTypes.QuantityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("QuantityTypes");
                });

            modelBuilder.Entity("FoodApp.Core.Domain.Recipes.RecipeStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Direction")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTimeOffset>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("StepNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeStep");
                });

            modelBuilder.Entity("FoodApp.Core.Domain.Foods.Food", b =>
                {
                    b.HasOne("FoodApp.Core.Domain.QuantityTypes.QuantityType", "QuantityType")
                        .WithMany("Foods")
                        .HasForeignKey("QuantityTypeId");

                    b.Navigation("QuantityType");
                });

            modelBuilder.Entity("FoodApp.Core.Domain.Foods.RecipeIngredient", b =>
                {
                    b.HasOne("FoodApp.Core.Domain.Foods.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FoodApp.Core.Domain.QuantityTypes.QuantityType", "QuantityType")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("QuantityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodApp.Core.Domain.Foods.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("QuantityType");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("FoodApp.Core.Domain.Recipes.RecipeStep", b =>
                {
                    b.HasOne("FoodApp.Core.Domain.Foods.Recipe", null)
                        .WithMany("RecipeSteps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodApp.Core.Domain.Foods.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");

                    b.Navigation("RecipeSteps");
                });

            modelBuilder.Entity("FoodApp.Core.Domain.QuantityTypes.QuantityType", b =>
                {
                    b.Navigation("Foods");

                    b.Navigation("RecipeIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
