using FoodApp.Client.Extensions;
using FoodApp.Core.Domain.QuantityTypes;
using FoodApp.Shared.Models.Recipes;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FoodApp.Client.Services.Recipes.RecipeImporterFormats
{
    /// <summary>
    /// Generic Recipe Format.
    /// Used for a best effort parsing
    /// </summary>
    public class RecipeParser : IRecipeParser
    {
        protected readonly HtmlDocument _document;

        public RecipeParser(HtmlDocument document)
        {
            _document = document;
        }
        #region Properties
        #endregion
        #region Public Methods
        public virtual IEnumerable<RecipeIngredientModel> GetIngredients()
        {
            var node = GetIngredientListNode();
            // could not find a node to parse
            if (node == null)
            {
                return Array.Empty<RecipeIngredientModel>();
            }
            var ingredients = new List<RecipeIngredientModel>();

            foreach (var listItem in node.GetChildElements())
            {
                // EX: "2 cups milk"
                // split on whitespace
                var recipeIngredientLabelParts = listItem.InnerText.Trim().Normalize().Split(' ').ToList();


                // The first part should always be part of the quantity
                var ingredientQuantity = recipeIngredientLabelParts[0];
                decimal amount;

                if (!decimal.TryParse(ingredientQuantity, out amount))
                {
                    amount = 0;
                    // this handles vulgar fractions (⅔ is parsed as ".67")
                    for (var i = 0; i < ingredientQuantity.Length; i++)
                    {
                        var parsedAmount = (decimal)CharUnicodeInfo.GetNumericValue(ingredientQuantity, i);
                        // getnumericvalue returns -1 if its not numeric
                        if (parsedAmount != -1)
                        {
                            amount += parsedAmount;
                        }
                    }
                }

                // we can remove the first parsed part
                recipeIngredientLabelParts.RemoveAt(0);

                var quantityType = recipeIngredientLabelParts.Where(l => CommonQuantityTypes.All.Any(q => string.Equals(q, l, StringComparison.InvariantCultureIgnoreCase))).FirstOrDefault();
                if (quantityType != null)
                {
                    recipeIngredientLabelParts.Remove(quantityType);
                }

                ingredients.Add(new RecipeIngredientModel
                {
                    Amount = amount,
                    QuantityType = quantityType,
                    // whatever's left in the list can be assumed to be the name
                    FoodName = string.Join(' ', recipeIngredientLabelParts)
                });
            }

            return ingredients;
        }

        public virtual string GetName()
        {
            // TODO -> improve this eventually. By default we can try to use semantic html for the page header.
            // This might conflict if the website includes their name in an h1 (with the recipe being h2) or doesn't adhere to semantic html (so we fallback to null)
            var pageHeaderElements = _document.GetHeaders();
            var h1Elements = pageHeaderElements.Where(el => el.Name == "h1");
            if (h1Elements.Count() == 1)
            {
                return h1Elements.Single().InnerText.Trim();
            }
            return null;
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Parse document for list node which should contain ingredients
        /// </summary>
        /// <returns>A single ul/li/dl node if it can be found, else null</returns>
        protected virtual HtmlNode GetIngredientListNode()
        {
            // ? We can likely safely remove any nodes that are nav related
            var listNodes = _document.GetPageLists().Where(el => !el.GetClassList().Any(c => c.Contains("nav")));
            if (listNodes.Count() > 1)
            {
                var ingredientListNodes = listNodes.Where(el => el.GetClassList().Any(c => c.Contains("ingredient"))).ToList();
                if (ingredientListNodes.Count == 1)
                {
                    return ingredientListNodes.Single();
                }
                else
                {
                    // TODO -> use "tbsp", "tsp", "cups" etc as a way of parsing
                    throw new NotImplementedException();
                }
            }
            // if there's only one list we can try returning it.
            return listNodes.SingleOrDefault();
        }
        #endregion
    }
}
