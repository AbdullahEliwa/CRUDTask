using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTask.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region R => Read Operations 
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region C => Create Operations
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);
        #endregion

        #region D => Delete Operations
        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);
        #endregion
    }
}
