using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity,bool>> exp,params string[] includes);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity,bool>> exp,params string[] includes);
        IQueryable<TEntity> GetAll(params string[] includes);
        Task<bool> IsExistAsync(Expression<Func<TEntity,bool>> exp,params string[] includes);

    }
}
