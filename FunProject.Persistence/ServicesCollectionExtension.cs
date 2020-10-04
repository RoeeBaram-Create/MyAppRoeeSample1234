using FunProject.Application.Data.Customers.Command;
using FunProject.Application.Data.Customers.Query;
using FunProject.Persistence.Customers.Command;
using FunProject.Persistence.Customers.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FunProject.Persistence
{
    public static class ServicesCollectionExtension
    {
        public static void AddPersistanceLayerServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("FunProjectDataBase"));
            
            // data services
            services.AddTransient<IGetAllCustomers, GetAllCustomers>();
            services.AddTransient<ICreateCustomer, CreateCustomer>();
        }
    }
}
