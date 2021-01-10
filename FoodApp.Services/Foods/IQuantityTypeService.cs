using FoodApp.Core.Domain.Foods;
using System.Threading.Tasks;

namespace FoodApp.Services.Foods
{
    public interface IQuantityTypeService
    {
        Task<QuantityType> EnsureCreatedAsync(string name);
    }
}