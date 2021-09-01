using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ECommerceSystem.DataParse
{
    public abstract class Repository<TEntity, TKey>
         : IRepository<TEntity, TKey>
         where TEntity : class, IEntity<TKey>
    {
        protected DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Remove(TKey id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
        public virtual IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity GetById(TKey id)
        {
            return _dbSet.Find(id);
        } 
    }
}
