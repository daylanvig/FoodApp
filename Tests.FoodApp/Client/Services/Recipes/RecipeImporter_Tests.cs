using AutoFixture;
using FoodApp.Client.Services;
using FoodApp.Client.Services.Recipes;
using FoodApp.Client.Services.Recipes.RecipeImporterFormats;
using FoodApp.Shared.Models.Recipes;
using HtmlAgilityPack;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tests.FoodApp.TestInfrastructure;
using Xunit;

namespace Tests.FoodApp.Client.Services.Recipes
{


    public class RecipeImporter_Test_Base : DefaultTestFixture<RecipeImporter>, IClassFixture<AllRecipes_AmishWhiteBread_Fixture>
    {
        class MockParser : IRecipeParser
        {
            public IEnumerable<global::FoodApp.Shared.Models.Recipes.RecipeIngredientModel> GetIngredients()
            {
                return new RecipeIngredientModel[]
                {
                    new RecipeIngredientModel()
                };
            }

            public string GetName()
            {
                return "Recipe Name";
            }
        }
        // generic url (not part of tests)
        private readonly string _url;

        public RecipeImporter_Test_Base(AllRecipes_AmishWhiteBread_Fixture fixture)
        {
            // for now just testing the one recipe, will need to figure out ways to handle different dom structures
            _url = fixture.URL;
            var recipe = fixture.TestRecipe;
            DoMock<IDomParser, Task<HtmlDocument>>(Task.FromResult(recipe));
            DoMock<IRecipeParserFactory, IRecipeParser>(new MockParser());
        }

        [Fact]
        public async Task ShouldThrowIfUrlIsNotProvided()
        {
            var argumentException = await Assert.ThrowsAsync<ArgumentException>(() => Sut.ParseRecipeFromUrl(string.Empty));
            Assert.Equal("url", argumentException.ParamName);
        }

        [Fact]
        public async Task ShouldReturnUrlIsTestUrl()
        {
            // Act
            var result = await Sut.ParseRecipeFromUrl(_url);
            // Assert
            Assert.Equal(_url, result.Url);
        }

        [Fact]
        public async Task ShouldReturnIngredients()
        {
            // Act
            var result = await Sut.ParseRecipeFromUrl(_url);
            // Assert
            Assert.Single(result.Ingredients);
        }
    }
}
