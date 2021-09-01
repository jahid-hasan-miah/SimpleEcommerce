using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.DataParse
{
    public interface IRepository<TEntity, TKey>
       where TEntity : class, IEntity<TKey>
    {
        void Add(TEntity entity);
        void Remove(TKey id);
        void Remove(TEntity entityToDelete);
        IList<TEntity> GetAll();
        TEntity GetById(TKey id);
    }
}
