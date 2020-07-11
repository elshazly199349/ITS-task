using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository.Interfaces
{
    public interface IRepositoryDTO<TEntity>:IRepository<TEntity> where TEntity:class 
    {
        TEntityModel GetByIdDTO<TEntityModel>(params object[] id) where TEntityModel : class;
        IEnumerable<TEntityModel> GetAllDTO<TEntityModel>() where TEntityModel : class;
        IEnumerable<TEntityModel> FindDTO<TEntityModel>(Expression<Func<TEntity, bool>> expression) where TEntityModel : class;

        TEntityModel AddDTO<TEntityModel>(TEntityModel model) where TEntityModel : class;
        IEnumerable<TEntityModel> AddRangeOfDTO<TEntityModel>(IEnumerable<TEntityModel> entityModels) where TEntityModel : class;

        void RemoveDTO<TEntityModel>(TEntityModel entityModel) where TEntityModel : class;
        void RemoveRangeOfDTO<TEntityModel>(IEnumerable<TEntityModel> entities) where TEntityModel : class;
        TEntityModel UpdateDTO<TEntityModel>(TEntityModel entity) where TEntityModel : class;
    }
}
