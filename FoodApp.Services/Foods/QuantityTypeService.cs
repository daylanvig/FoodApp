using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using System.Threading.Tasks;

namespace FoodApp.Services.Foods
{
    public class QuantityTypeService : IQuantityTypeService
    {
        private readonly IRepository<QuantityType> _quantityTypeRepository;
        public QuantityTypeService(IRepository<QuantityType> quantityTypeRepository)
        {
            _quantityTypeRepository = quantityTypeRepository;
        }

        public async Task<QuantityType> EnsureCreatedAsync(string name)
        {
            QuantityType existingQuantityType = await _quantityTypeRepository.FindAsync(q => q.Type == name);
            // No duplicates - if exists, reus existing.
            if (existingQuantityType != null)
            {
                return existingQuantityType;
            }
            var quantityType = QuantityType.CreateNew(name);
            await _quantityTypeRepository.AddAsync(quantityType);
            return quantityType;
        }
    }
}
