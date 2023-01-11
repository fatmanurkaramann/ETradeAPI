using ETradeAPI.Core.Entities;
using ETradeAPI.Core.Wrappers.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Core.DataAccess
{
    public interface IEntityRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
                IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = true);
        Task<TEntity> GetByIdAsync(string id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool tracking = true);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Add(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        Task<int> DeleteAsync(TEntity entity);
        int Delete(TEntity entity);
        Task<int> DeleteByIdAsync(string id);
        int DeleteById(string id);
        bool DeleteRange(Expression<Func<TEntity, bool>> predicate);
        Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
