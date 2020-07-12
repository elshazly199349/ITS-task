using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer.DbContexts;
using BussinessLogicLayer.Classes;
using InterfacesLayer.Intefaces;
using ContainerLayer.AutoMapper;

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
