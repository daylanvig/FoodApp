using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodApp.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> AddAsync(TEntity entity);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> whereCondition);
        Task<TEntity> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> whereCondition = null, params string[] includes);
    }
}