using AutoMapper;
using BussinessLogicLayer.Intefaces;
using DataAccessLayer.Repository.Classes;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogicLayer.Classes
{
    public class ItemManager:ItemRepository,IItemManager
    {
        public ItemManager(DbContext dbContext,IMapper mapper) : base(dbContext,mapper) { }
    }
}
