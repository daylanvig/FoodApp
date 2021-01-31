using Core;
using Core.Domain.Common;
using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.QuantityTypes;

namespace FoodApp.Core.Domain.Foods
{
    /// <summary>
    /// Entity representing food
    /// </summary>
    /// <remarks>
    /// Food may be an item in someone's pantry, or it may be used as part of a recipe
    /// </remarks>
    /// <seealso cref="Core.Domain.Common.BasePrivateEntity" />
    public class Food : BasePrivateEntity
    {
        #region Properties
        public string Name { get; private set; }
        public decimal AmountOnHand { get; private set; }
        public QuantityType QuantityType { get; private set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Parameterless ctor - Required by EF
        /// </summary>
        public Food()
        {
            // todo -> add more to this once lists are added
        }

        /// <summary>
        /// Ctor - New Food
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amountOnHand"></param>
        /// <param name="quantityType"></param>
        private Food(string name, decimal amountOnHand, QuantityType quantityType) : this()
        {
            Name = name;
            AmountOnHand = amountOnHand;
            QuantityType = quantityType;
        }
        #endregion
        #region Static Methods
        /// <summary>
        /// Creates the new food item
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="amountOnHand">The amount on hand.</param>
        /// <returns></returns>
        public static Food CreateNew(string name, decimal amountOnHand, QuantityType quantityType)
        {
            return new Food(name, amountOnHand, quantityType);
        }
        #endregion
        #region Public Methods
        public void UpdateName(string name)
        {
            Guard.AgainstNullOrEmpty(name, GetPropertyIdentifier(nameof(name)));
            IsCreated();

            Name = name;
        }

        public void UpdateQuantityType(QuantityType quantityType)
        {
            Guard.AgainstNull(quantityType, GetPropertyIdentifier(nameof(quantityType)));
            IsCreated();

            QuantityType = quantityType;
        }

        /// <summary>
        /// Updates the quantity on hand.
        /// </summary>
        /// <param name="newQuantity">The new quantity.</param>
        /// <exception cref="EntityIsNotCreatedException">Thrown is entity has not saved</exception>
        public void UpdateQuantityOnHand(decimal newQuantity)
        {
            IsCreated();

            if (newQuantity < 0)
            {
                throw new FoodQuantityMustBeGreaterThanZeroException(Name);
            }
            AmountOnHand = newQuantity;
        }
        #endregion
        #region Helpers
        private string GetPropertyIdentifier(string property)
        {
            return $"{nameof(Food)} - {property}";
        }
        #endregion
    }
}
