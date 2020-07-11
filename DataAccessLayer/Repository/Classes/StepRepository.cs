using AutoMapper;
using DataAccessLayer.Repository.Interfaces;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository.Classes
{
    public abstract class StepRepository:RepositoryDTO<Step>, IStepRepository
    {
        public StepRepository(DbContext dbContext,IMapper mapper) : base(dbContext,mapper) { }
    }
}
