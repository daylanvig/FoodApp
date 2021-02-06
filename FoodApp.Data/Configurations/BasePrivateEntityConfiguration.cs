using FoodApp.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodApp.Data.Configurations
{
    public class BasePrivateEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BasePrivateEntity
    {
        private readonly string _applicationUserId;

        public BasePrivateEntityConfiguration(string applicationUserId)
        {
            _applicationUserId = applicationUserId;
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigurationsHelper.ApplyBaseEntityConfiguration(builder);
            builder.Property("_applicationUserId");
            builder.HasQueryFilter(b => EF.Property<string>(b, "_applicationUserId") == _applicationUserId);
        }
    }
}
