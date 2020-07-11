using AutoMapper;
using DomainModels.DTOs;
using DomainModels.Models;

namespace DomainModels.AutoMapper
{
    public class AutoMapperProfiler:Profile
    {
        public AutoMapperProfiler() {
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Step, StepDto>().ReverseMap();
        }
    }
}
