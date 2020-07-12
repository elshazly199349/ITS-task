using AutoMapper;
using DataAccessLayer.Models;
using DomainModels.DTOs;

namespace ContainerLayer.AutoMapper
{
    public class AutoMapperProfiler:Profile
    {
        public AutoMapperProfiler() {
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Step, StepDto>().ReverseMap();
        }
    }
}
