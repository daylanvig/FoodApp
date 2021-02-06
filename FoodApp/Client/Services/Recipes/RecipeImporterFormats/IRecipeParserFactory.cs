using HtmlAgilityPack;

namespace FoodApp.Client.Services.Recipes.RecipeImporterFormats
{
    public interface IRecipeParserFactory
    {
        IRecipeParser GetFormatter(string url, HtmlDocument document);
    }
}