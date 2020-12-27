using Core.Domain.Common;
using FoodApp.Core.Domain.Foods;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Data
{
    public interface IDataContext
    {
        DbSet<Food> Foods { get; set; }
        DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        DbSet<Recipe> Recipes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
       DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
    }
}
