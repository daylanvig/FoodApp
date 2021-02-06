using FoodApp.Client.Services.Recipes.RecipeImporterFormats;
using System.Linq;
using Xunit;

namespace Tests.FoodApp.Client.Services.Recipes
{
    public class RecipeParser_Tests : IClassFixture<AllRecipes_AmishWhiteBread_Fixture>
    {
        private readonly RecipeParser _sut;

        public RecipeParser_Tests(AllRecipes_AmishWhiteBread_Fixture fixture)
        {
            _sut = new RecipeParser(fixture.TestRecipe);
        }

        [Fact]
        public void ShouldParseRecipeNameIsAmishWhiteBread()
        {
            // Act
            var result = _sut.GetName();
            // Assert
            Assert.Equal("Amish White Bread", result);
        }

        [Fact]
        public void ShouldReturnIngredients()
        {
            // Act
            var results = _sut.GetIngredients().ToList();
            // Assert
            var warmWater = results[0];
            Assert.Equal(2, warmWater.Amount);
            Assert.Equal("cups", warmWater.QuantityType);
            Assert.Equal("warm water (110 degrees F/45 degrees C)", warmWater.FoodName);

            // this is in the recipe as a vulgar fraction "1 ½"
            var yeast = results[2];
            Assert.Equal(1.5m, yeast.Amount);
            Assert.Equal("tablespoons", yeast.QuantityType);
            Assert.Equal("active dry yeast", yeast.FoodName);

            Assert.Equal(6, results.Count);
        }
    }
}
