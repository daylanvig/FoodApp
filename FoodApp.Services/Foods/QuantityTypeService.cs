using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<QuantityType>> EnsureCreatedAsync(IEnumerable<string> names)
        {
            var uniqueNames = names.Distinct();
            List<QuantityType> quantityTypes = new List<QuantityType>(uniqueNames.Count());

            var existingTypes = await _quantityTypeRepository.ToListAsync(q => names.Contains(q.Type));
            foreach (var quantityName in uniqueNames)
            {
                var existingType = existingTypes.SingleOrDefault(q => q.Type == quantityName);
                if (existingType == null)
                {
                    existingType = QuantityType.CreateNew(quantityName);
                    await _quantityTypeRepository.AddAsync(existingType);
                }
                quantityTypes.Add(existingType);
            }
            return quantityTypes;
        }
    }
}
