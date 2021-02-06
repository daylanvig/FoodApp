using FoodApp.Client.Extensions;
using FoodApp.Client.Services.Recipes.RecipeImporterFormats;
using FoodApp.Core.Common.Guards;
using FoodApp.Shared.Helpers;
using FoodApp.Shared.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;

namespace FoodApp.Client.Services.Recipes
{
    public class RecipeImporter
    {
        private readonly IDomParser _domParser;
        private readonly IRecipeParserFactory _recipeImporterFormatFactory;

        public RecipeImporter(IDomParser domParser, IRecipeParserFactory recipeImporterFormatFactory)
        {
            _domParser = domParser;
            _recipeImporterFormatFactory = recipeImporterFormatFactory;
        }


        public async Task<RecipeModel> ParseRecipeFromUrl(string url)
        {
            Guard.AgainstNullOrEmpty(url, nameof(url));
            var recipeModel = new RecipeModel
            {
                Url = url
            };
            var recipeDocument = await _domParser.ParseFromUrlAsync(url);
            var parser = _recipeImporterFormatFactory.GetFormatter(url, recipeDocument);
            recipeModel.Name = parser.GetName();
            recipeModel.Ingredients = parser.GetIngredients().ToList();
            return recipeModel;
        }
    }
}
