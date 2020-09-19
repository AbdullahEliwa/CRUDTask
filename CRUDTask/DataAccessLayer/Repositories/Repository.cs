using CRUDTask.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CRUDTask.DataAccessLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entities;
        public Repository(ApplicationDbContext context)
        {
            this._context = context;
            _entities = _context.Set<TEntity>();
        }


        #region R => Read Operations
        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }
        #endregion

        #region C => Create Operations
        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }
        #endregion

        #region D => Delete Operations
        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }
        #endregion
    }
}