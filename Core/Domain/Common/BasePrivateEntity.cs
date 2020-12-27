using FoodApp.Core.Domain.Accounts;

namespace Core.Domain.Common
{
    /// <summary>
    /// Entity belonging to one user
    /// </summary>
    /// <seealso cref="Core.BaseEntity" />
    public abstract class BasePrivateEntity : BaseEntity
    {
        private string _applicationUserId;
    }
}
