using FoodApp.Core.Domain.Foods;
using FoodApp.Shared.Models.Recipes;
using HtmlAgilityPack;
using System.Collections;
using System.Collections.Generic;

namespace FoodApp.Client.Services.Recipes.RecipeImporterFormats
{
    public interface IRecipeParser
    {
        string GetName();
        IEnumerable<RecipeIngredientModel> GetIngredients();
    }
}
