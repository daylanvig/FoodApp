﻿using FoodApp.Core.Domain.Common;
using FoodApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodApp.Data.Repositories
{
    /// <summary>
    /// Generic repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDataContext _database;
        private readonly DbSet<TEntity> _table;

        public Repository(IDataContext database)
        {
            _database = database;
            _table = _database.Set<TEntity>();
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            _table.Add(entity);
            return await _database.SaveChangesAsync();
        }

        public Task<TEntity> GetByIdAsync(int id,params string[] includes)
        {
            IQueryable<TEntity> queryItems = _table;
            foreach (var include in includes)
            {
                queryItems = queryItems.Include(include);
            }
            return queryItems.SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<int> EditAsync(TEntity entity)
        {
            _table.Update(entity);
            return _database.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            _table.Remove(entity);
            return _database.SaveChangesAsync();
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            return _table.SingleOrDefaultAsync(whereCondition);
        }

        public async Task<IReadOnlyList<TEntity>> ToListAsync(
            Expression<Func<TEntity, bool>> whereCondition = null,
            params string[] includes)
        {
            IQueryable<TEntity> queryItems = _table;
            foreach(var include in includes)
            {
                queryItems = queryItems.Include(include);
            }

            if (whereCondition != null)
            {
                return (await queryItems.Where(whereCondition).ToListAsync()).ToImmutableList();
            }
            return (await queryItems.ToListAsync()).ToImmutableList();
        }
    }
}
