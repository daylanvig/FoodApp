using FoodApp.Core.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodApp.Data.Configurations
{
    public class ConfigurationsHelper
    {
        public static void ApplyBaseEntityConfiguration<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder
                .HasKey(b => b.Id);
            builder
                .Property(b => b.CreatedOn)
                .ValueGeneratedOnAdd();
            builder
                .Property(b => b.LastModifiedOn)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
