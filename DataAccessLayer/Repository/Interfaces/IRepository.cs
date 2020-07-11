using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(params object[] id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);

        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void Remove(params object[] id);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveRange(Expression<Func<TEntity, bool>> predicate);

        TEntity Update(TEntity entity);
        void SaveChanges();
    }
}
