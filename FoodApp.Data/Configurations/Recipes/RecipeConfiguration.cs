using FoodApp.Core.Domain.Foods;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodApp.Data.Configurations.Recipes
{
    public class RecipeConfiguration : BasePrivateEntityConfiguration<Recipe>
    {
        public RecipeConfiguration(string applicationUserId) : base(applicationUserId)
        {
        }

        public override void Configure(EntityTypeBuilder<Recipe> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Name)
                   .HasMaxLength(150)
                   .IsRequired();
        }
    }
}
