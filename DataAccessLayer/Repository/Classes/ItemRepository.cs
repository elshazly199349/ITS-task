using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository.Classes
{
    public abstract class ItemRepository:RepositoryDTO<Item>,IItemRepository
    {
        public ItemRepository(DbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
