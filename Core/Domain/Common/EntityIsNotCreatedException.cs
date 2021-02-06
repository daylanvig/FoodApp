using System;

namespace FoodApp.Core.Domain.Common
{
    public class EntityIsNotCreatedException : Exception
    {
        public EntityIsNotCreatedException(string message) : base (message)
        {

        }
    }
}
