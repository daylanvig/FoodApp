using Core.Domain.Common;
using FoodApp.Core.Common;
using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Core.Domain.QuantityTypes
{
    public class QuantityType : BasePrivateEntity
    {
        public string Type { get; private set; }

        public IReadOnlyCollection<Food> Foods { get; private set; }
        public IReadOnlyCollection<RecipeIngredient> RecipeIngredients { get; private set; }

        public QuantityType() : base()
        {
            Foods = new List<Food>();
            RecipeIngredients = new List<RecipeIngredient>();
        }

        private QuantityType(string type) : this()
        {
            Type = type;
        }

        /// <summary>
        /// Create a new quantity type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static QuantityType CreateNew(string type)
        {
            return new QuantityType(type);
        }

        public void UpdateType(string type)
        {
            IsCreated();
            Guard.AgainstNullOrEmpty(type, nameof(Type));
            Type = type;
        }

        /// <summary>
        /// Checks if quantity type can be deleted.
        /// </summary>
        /// <exception cref="QuantityTypeInUseException">If is in use</exception>
        public void CheckIfCanBeDeleted()
        {
            if(Foods.Any() || RecipeIngredients.Any())
            {
                throw new QuantityTypeInUseException(RecipeIngredients, Foods);
            }
        }
    }
}
