using Core;
using Core.Domain.Common;
using FoodApp.Core.Common;
using System;

namespace FoodApp.Core.Domain.Foods
{
    /// <summary>
    /// Entity representing food
    /// </summary>
    /// <seealso cref="Core.Domain.Common.BasePrivateEntity" />
    public class Food : BasePrivateEntity
    {
        public string Name { get; private set; }
        public decimal AmountOnHand { get; private set; }
        public QuantityType QuantityType { get; private set; }

        public Food()
        {
            // todo -> add more to this once lists are added
        }

        private Food(string name, decimal amountOnHand, QuantityType quantityType) : this()
        {
            Name = name;
            AmountOnHand = amountOnHand;
            QuantityType = quantityType;
        }

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


        private string GetPropertyIdentifier(string property)
        {
            return $"{nameof(Food)} - {property}";
        }
    }
}
