using AutoMapper;
using FunProject.Application.CustomersModule.Dtos;
using FunProject.Domain.Entities;

namespace FunProject.Infrastructure.Mapper.Mapping
{
    public class CustomerMap : Profile
    {
        public CustomerMap()
        {
            CreateMap<Customer, CustomerDto>();
            
            CreateMap<CustomerDto, Customer>();
        }
    }
}
