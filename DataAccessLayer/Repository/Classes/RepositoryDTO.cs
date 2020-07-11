using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository.Classes
{
    public abstract class RepositoryDTO<TEntity> : Repository<TEntity>, IRepositoryDTO<TEntity> where TEntity : class
    {
        private readonly IMapper _mapper;
        public RepositoryDTO(DbContext context,IMapper mapper) : base(context) {
            _mapper = mapper;
        }

        public virtual TEntityModel AddDTO<TEntityModel>(TEntityModel model) where TEntityModel : class
        {
            var entity= _mapper.Map<TEntity>(model);
            var res=Add(entity);
            model = _mapper.Map<TEntityModel>(res);
            return model;
        }
        public virtual IEnumerable<TEntityModel> AddRangeOfDTO<TEntityModel>(IEnumerable<TEntityModel> entityModels) where TEntityModel : class
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(entityModels);
            var res = AddRange(entities);
            if (res == null) return null;
            entityModels = _mapper.Map<IEnumerable<TEntityModel>>(res);
            return entityModels;
        }

        public virtual IEnumerable<TEntityModel> FindDTO<TEntityModel>(Expression<Func<TEntity, bool>> expression) where TEntityModel : class
        {
            var res = _entities.Where(expression).ProjectTo<TEntityModel>(_mapper.ConfigurationProvider).ToList();
            return res;
        }
        public virtual IEnumerable<TEntityModel> GetAllDTO<TEntityModel>() where TEntityModel : class
        {
            var res = _entities.ProjectTo<TEntityModel>(_mapper.ConfigurationProvider).ToList();
            return res;
        }

        public virtual TEntityModel GetByIdDTO<TEntityModel>(params object[] id) where TEntityModel:class
        {
            var entity = GetById(id);
            if (entity == null) return null;
            var dto = _mapper.Map<TEntityModel>(entity);
            return dto;
        }

        public virtual void RemoveDTO<TEntityModel>(TEntityModel entityModel) where TEntityModel : class
        {
            var entity = _mapper.Map<TEntity>(entityModel);
            if (entity!=null)
            {
                Remove(entity);
            }
        }

        public virtual void RemoveRangeOfDTO<TEntityModel>(IEnumerable<TEntityModel> entities) where TEntityModel : class
        {
            var dtos = _mapper.Map<IEnumerable<TEntity>>(entities);
            RemoveRange(dtos);
        }

        public virtual TEntityModel UpdateDTO<TEntityModel>(TEntityModel entityModel) where TEntityModel : class
        {
            var entity = _mapper.Map<TEntity>(entityModel);
            entity= Update(entity);
            entityModel = _mapper.Map<TEntityModel>(entity);
            return entityModel;
        }
    }
}
