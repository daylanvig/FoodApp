using FoodApp.Client.Services;
using FoodApp.Core.Common;
using HtmlAgilityPack;
using Tests.FoodApp.TestInfrastructure;

namespace Tests.FoodApp.Client.Services.Recipes
{
    /// <summary>
    /// RecipeImporter IClassFixture 
    /// </summary>
    /// <remarks>
    /// This fixture is being used 
    /// </remarks>
    public class AllRecipes_AmishWhiteBread_Fixture
    {
        readonly string _recipeContent;

        public readonly string URL = "www.allrecipes.com";

        public AllRecipes_AmishWhiteBread_Fixture()
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
}
