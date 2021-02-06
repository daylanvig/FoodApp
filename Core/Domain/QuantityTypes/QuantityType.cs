using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.Common;
using FoodApp.Core.Domain.Foods;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Core.Domain.QuantityTypes
{
    /// <summary>
    /// QuantityType Entity
    /// </summary>
    public class QuantityType : BasePrivateEntity
    {
        #region Properties
        public string Type { get; private set; } // todo -> maybe rename this to something more identifiable?
        #endregion
        #region Properties - OneToManyRelations
        /// <summary>
        /// Foods - Foods in pantry that use this quantity type
        /// </summary>
        /// <see cref="_foods"/>
        public IReadOnlyCollection<Food> Foods 
        { 
            get => _foods; 
            private set
            {
                _foods = value.ToList();
            } 
        }
        /// <summary>
        /// RecipeIngredients - RecipeIngredients that use this quantity type
        /// </summary>
        /// <see cref="_recipeIngredients"/>
        public IReadOnlyCollection<RecipeIngredient> RecipeIngredients 
        { 
            get => _recipeIngredients; 
            private set
            {
                _recipeIngredients = value.ToList();
            }
        }
        #endregion
        #region BackingFields
        /// <summary>
        /// _foods - Backing field for EF
        /// </summary>
        private List<Food> _foods;
        /// <summary>
        /// _recipeIngredients - Backing field for EF
        /// </summary>
        private List<RecipeIngredient> _recipeIngredients;
        #endregion
        #region Constructors
        /// <summary>
        /// Ctor - for EF
        /// </summary>
        public QuantityType() : base()
        {
            Foods = new List<Food>();
            RecipeIngredients = new List<RecipeIngredient>();
        }

        /// <summary>
        /// Ctor - Creating new quantity type
        /// </summary>
        /// <param name="type"></param>
        private QuantityType(string type) : this()
        {
            Type = type;
        }
        #endregion
        #region Static Methods
        /// <summary>
        /// Create a new quantity type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static QuantityType CreateNew(string type)
        {
            return new QuantityType(type);
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Update the type of quantity type
        /// </summary>
        /// <param name="type"></param>
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
        #endregion
    }
}
