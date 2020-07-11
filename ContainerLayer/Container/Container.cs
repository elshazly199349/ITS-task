using AutoMapper;
using BussinessLogicLayer.Classes;
using BussinessLogicLayer.Intefaces;
using DataAccessLayer.DbContexts;
using DomainModels.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContainerLayer.Container
{
    public static class Container
    {
        public static void InjectDependencies(this IServiceCollection services,string connectionString) {
            services.AddDbContextPool<DbContext,ApplicationDbContext>(options=> {
                options.UseSqlServer(connectionString);
            });
            services.AddAutoMapper(typeof(AutoMapperProfiler));
            services.AddScoped<IStepManager, StepManager>();
            services.AddScoped<IItemManager, ItemManager>();
        }
    }
}
