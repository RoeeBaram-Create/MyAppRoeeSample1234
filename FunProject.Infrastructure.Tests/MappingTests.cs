using AutoMapper;
using FunProject.Application.ActivityLogModule.Dtos;
using FunProject.Application.CustomersModule.Dtos;
using FunProject.Domain.Entities;
using FunProject.Infrastructure.Mapper;
using FunProject.Infrastructure.Mapper.Mapping;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace FunProject.Infrastructure.Tests
{
    [TestFixture]
    public class MappingTests
    {
        private  IConfigurationProvider _configuration;
        private  IMapper _mapper;
       
        [SetUp]
        public void SetUp()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ActivityLogMap>();
                cfg.AddProfile<CustomerMap>();  
            });

            _mapper = _configuration.CreateMapper();
        }


        [Test]
        [TestCase(typeof(CustomerDto), typeof(Customer))]
        [TestCase(typeof(Customer), typeof(CustomerDto))]
        [TestCase(typeof(ActivityLog), typeof(ActivityLogDto))]
        
        public void ShouldSupportMappingFromSourceToDestination_MappingIsValid(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);
            _mapper.Map(instance, source, destination);
        }


        [Test]
        
        [TestCase(typeof(ActivityLogDto), typeof(ActivityLog))]
        public void ShouldNotSupportMappingFromSourceToDestination_ThrowsAutoMapperMappingException(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            Assert.Throws<AutoMapperMappingException>(() => _mapper.Map(instance, source, destination));

        }
    }


}