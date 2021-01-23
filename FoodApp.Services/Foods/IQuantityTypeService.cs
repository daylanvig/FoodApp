using FoodApp.Core.Domain.QuantityTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Services.Foods
{
    public interface IQuantityTypeService
    {
        Task<QuantityType> EnsureCreatedAsync(string name);
        /// <summary>
        /// Ensures all quantity types are created
        /// </summary>
        /// <param name="names">The names.</param>
        /// <returns>The quantity types</returns>
        Task<IEnumerable<QuantityType>> EnsureCreatedAsync(IEnumerable<string> names);
    }
}