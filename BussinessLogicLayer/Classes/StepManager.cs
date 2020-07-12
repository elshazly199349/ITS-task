using AutoMapper;
using DataAccessLayer.Repository.Classes;
using InterfacesLayer.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogicLayer.Classes
{
    public class StepManager:StepRepository,IStepManager
    {
        public StepManager(DbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
