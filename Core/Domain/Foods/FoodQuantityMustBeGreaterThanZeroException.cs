using System;

namespace FoodApp.Core.Domain.Foods
{
    public class FoodQuantityMustBeGreaterThanZeroException : Exception
    {
        public FoodQuantityMustBeGreaterThanZeroException(string foodName): base ($"{foodName}'s quantity can not be less than 0") { }
    }
}
