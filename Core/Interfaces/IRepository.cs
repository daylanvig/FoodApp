using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodApp.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> AddAsync(TEntity entity);
        Task<int> EditAsync(TEntity entity);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> whereCondition);
        Task<TEntity> GetByIdAsync(int id, params string[] includes);
        Task<IReadOnlyList<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> whereCondition = null, params string[] includes);
    }
}