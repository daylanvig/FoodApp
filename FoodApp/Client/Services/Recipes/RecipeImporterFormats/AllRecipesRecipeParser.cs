using FoodApp.Client.Extensions;
using FoodApp.Core.Common.Guards;
using HtmlAgilityPack;
using System.Linq;

namespace FoodApp.Client.Services.Recipes.RecipeImporterFormats
{
    public class AllRecipesRecipeParser : RecipeParser
    {
        public AllRecipesRecipeParser(HtmlDocument document) : base(document)
        {
        }

        #region Public Methods
        public override string GetName()
        {
            // allrecipes adheres to semantic html. We're guaranteed to have a single h1 containing the recipe contents
            var name = base.GetName();
            Guard.AgainstNullOrEmpty(name, nameof(_document));
            return name;
        }
        #endregion
    }
}
