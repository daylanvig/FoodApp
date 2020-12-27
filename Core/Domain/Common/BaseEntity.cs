using System;

namespace Core.Domain.Common
{
    /// <summary>
    /// General entity, shared between users
    /// </summary>
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }


        /// <summary>
        /// Determines whether this instance is created.
        /// </summary>
        /// <exception cref="Core.EntityIsNotCreatedException">Entity was not saved (id is 0)</exception>
        protected void IsCreated()
        {
            if (Id == 0)
            {
                throw new EntityIsNotCreatedException("Entity was not saved");
            }
        }
    }
}
