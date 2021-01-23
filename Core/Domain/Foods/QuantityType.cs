using Core.Domain.Common;
using FoodApp.Core.Common;

namespace FoodApp.Core.Domain.Foods
{
    public class QuantityType : BasePrivateEntity
    {
        public string Type { get; private set; }

        public QuantityType() : base()
        {

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
    }
}
