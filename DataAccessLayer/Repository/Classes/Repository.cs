using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository.Classes
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(DbContext context) {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
  
        public virtual TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }
        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            return entities;
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).AsNoTracking();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.AsNoTracking();
        }
        public virtual TEntity GetById(params object[] id)
        {
            var entity= _entities.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public virtual void Remove(params object[] id)
        {
            var entity = GetById(id);
            if (entity!=null)
            {
                _entities.Remove(entity);
            }
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
        public virtual void RemoveRange(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            if (entity!=null)
            {
                _context.Entry(entity).State = EntityState.Modified;
             //  entity= _context.Update<TEntity>(entity).Entity;
            }
            return entity;
        }
    }
}
