using System;

namespace Core.Domain.Common
{
    /// <summary>
    /// Entity belonging to one user
    /// </summary>
    /// <seealso cref="Core.BaseEntity" />
    public abstract class BasePrivateEntity : BaseEntity
    {
        private string _applicationUserId;

        public void SetApplicationUserId(string applicationUserId)
        {
            if (string.IsNullOrEmpty(applicationUserId))
            {
                throw new ArgumentNullException(nameof(applicationUserId));
            }

            if (!string.IsNullOrEmpty(_applicationUserId) && applicationUserId != _applicationUserId)
            {
                throw new CantChangeEntitiesApplicationUserIdException();
            }

            _applicationUserId = applicationUserId;
        }
    }
}
