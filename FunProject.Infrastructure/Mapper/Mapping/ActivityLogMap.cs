using AutoMapper;
using FunProject.Application.ActivityLogModule.Dtos;
using FunProject.Domain.Enums;
using FunProject.Persistence;

namespace FunProject.Infrastructure.Mapper.Mapping
{
    public class ActivityLogMap : Profile
    {
        public ActivityLogMap()
        {
            CreateMap<ActivityLog, ActivityLogDto>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
                .ForMember(d => d.CustomerId, s => s.MapFrom(x => x.CustomerId))
                .ForMember(d => d.ActivityDate, s => s.MapFrom(x => x.ActivityDate))
                .ForMember(d => d.FirstName, s => s.MapFrom(x => x.Customer.FirstName))
                .ForMember(d => d.LastName, s => s.MapFrom(x => x.Customer.LastName))
                .ForMember(d => d.ActionType, s => s.MapFrom(x => (ActionType)x.ActionType));
        }
    }
}
