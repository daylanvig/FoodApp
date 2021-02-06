using FoodApp.Core.Common.Guards;
using FoodApp.Shared.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Client.Services.Recipes
{
    public class RecipeImporter
    {
        private readonly IDomParser _domParser;

        public RecipeImporter(IDomParser domParser)
        {
            _domParser = domParser;
        }


        public async Task<RecipeModel> ParseRecipeFromUrl(string url)
        {
            Guard.AgainstNullOrEmpty(url, nameof(url));



            throw new NotImplementedException();
        }
    }
}
