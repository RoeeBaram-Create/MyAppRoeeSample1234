using AutoMapper;
using FunProject.Domain.Logger;
using FunProject.Domain.Mapper;
using FunProject.Infrastructure.Logger;
using FunProject.Infrastructure.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FunProject.Domain
{
    public static class ServicesCollectionExtension
    {
        public static void AddInrustractureLayerServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Custom Logger Adapter to abstract Logger dependicy from Core layers.
            services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
            // Custom Mapper Adapter to abstract Mapper dependicy from Core layers.
            services.AddSingleton<IMapperAdapter, MapperAdapter>();
        }
    }
}
