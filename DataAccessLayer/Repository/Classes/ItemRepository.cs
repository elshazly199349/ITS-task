using AutoMapper;
using DataAccessLayer.Repository.Interfaces;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository.Classes
{
    public abstract class ItemRepository:RepositoryDTO<Item>,IItemRepository
    {
        public ItemRepository(DbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
