using AutoMapper;
using BussinessLogicLayer.Intefaces;
using DataAccessLayer.Repository.Classes;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogicLayer.Classes
{
    public class StepManager:StepRepository,IStepManager
    {
        public StepManager(DbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
