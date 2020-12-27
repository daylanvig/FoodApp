using System;

namespace Core
{
    public class EntityIsNotCreatedException : Exception
    {
        public EntityIsNotCreatedException(string message) : base (message)
        {

        }
    }
}
