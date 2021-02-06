using FoodApp.Client.Services;
using FoodApp.Client.Services.Recipes;
using FoodApp.Core.Common;
using HtmlAgilityPack;
using System;
using System.Threading.Tasks;
using Tests.FoodApp.TestInfrastructure;
using Xunit;

namespace Tests.FoodApp.Client.Services.Recipes
{
    /// <summary>
    /// RecipeImporter IClassFixture 
    /// </summary>
    /// <remarks>
    /// This fixture is being used 
    /// </remarks>
    public class RecipeImporter_Fixture
    {
        readonly string _recipeContent;

        public RecipeImporter_Fixture()
        {
            _recipeContent = ResourceHelper.ReadEmbedded("AllRecipes_AmishWhiteBread.html", TestHelpers.TestAssembly).Result;
        }

        public HtmlDocument TestRecipe
        {
            get
            {
                var parser = new DomParser();
                return parser.ParseFromString(_recipeContent);
            }
        }
    }


    public class RecipeImporter_Test_Base : DefaultTestFixture<RecipeImporter>, IClassFixture<RecipeImporter_Fixture>
    {
        // generic url (not part of tests)
        const string URL = "www.url.ca";

        public RecipeImporter_Test_Base(RecipeImporter_Fixture fixture)
        {
            // for now just testing the one recipe, will need to figure out ways to handle different dom structures
            var recipe = fixture.TestRecipe;
            DoMock<IDomParser, Task<HtmlDocument>>(Task.FromResult(recipe));
        }

        [Fact]
        public async Task ShouldThrowIfUrlIsNotProvided()
        {
            var argumentException = await Assert.ThrowsAsync<ArgumentException>(() => Sut.ParseRecipeFromUrl(string.Empty));
            Assert.Equal("url", argumentException.ParamName);
        }

        [Fact]
        public async Task ShouldParseRecipeNameIsAmishWhiteBread()
        {
            // Arrange

            // Act
            var result = await Sut.ParseRecipeFromUrl(URL);
            // Assert
            Assert.Equal("Amish White Bread", result.Name);
        }
    }
}
