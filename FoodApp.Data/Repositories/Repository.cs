using Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _table.SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            return _table.SingleOrDefaultAsync(whereCondition);
        }

        public async Task<IReadOnlyList<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> whereCondition = null)
        {
            if (whereCondition != null)
            {
                return (await _table.Where(whereCondition).ToListAsync()).ToImmutableList();
            }
            return (await _table.ToListAsync()).ToImmutableList();
        }
    }
}
