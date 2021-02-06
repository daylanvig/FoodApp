using FoodApp.Core.Domain.Common;
using System;
using System.Linq;

namespace FoodApp.Data
{
    public static class DataContextExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataContext"></param>
        /// <param name="tenantId"></param>
        public static void SetApplicationUserId(this DataContext dataContext, string tenantId)
        {
            var addedItems = dataContext.ChangeTracker.Entries()
                        .Where(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added && e.Entity.GetType().BaseType == typeof(BasePrivateEntity))
                        .ToList();
            if (addedItems.Any())
            {
                if (string.IsNullOrEmpty(tenantId))
                {
                    throw new ArgumentException("Can't save private entities without a tenantId", nameof(tenantId));
                }

                foreach (var addedItem in addedItems)
                {
                    ((BasePrivateEntity)addedItem.Entity).SetApplicationUserId(tenantId);
                }

            }
        }
    }
}
