using FoodApp.Core.Common;
using HtmlAgilityPack;

namespace FoodApp.Client.Services.Recipes.RecipeImporterFormats
{
    public class RecipeImporterFormatFactory : IRecipeParserFactory
    {
        public IRecipeParser GetFormatter(string url, HtmlDocument document)
        {
            if (url.ContainsInsensitive("allrecipes.com"))
            {
                return new AllRecipesRecipeParser(document);
            }

            return new RecipeParser(document);
        }
    }
}
