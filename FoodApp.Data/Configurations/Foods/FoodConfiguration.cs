using FoodApp.Core.Domain.Foods;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodApp.Data.Configurations.Foods
{
    public class FoodConfiguration : BasePrivateEntityConfiguration<Food>
    {
        public FoodConfiguration(string applicationUserId) : base(applicationUserId)
        {

        }

        public override void Configure(EntityTypeBuilder<Food> builder)
        {
            base.Configure(builder);
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
