﻿using Core.Domain.Common;
using FoodApp.Core.Domain.Foods;
using FoodApp.Data.Configurations.Foods;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Data
{
    public class DataContext : DbContext, IDataContext
    {
        private string _tenantId;

        public DataContext(DbContextOptions<DataContext> options, string tenantId) : base(options)
        {
            _tenantId = tenantId;
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity: BaseEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new FoodConfiguration(_tenantId));
        }
    }
}
