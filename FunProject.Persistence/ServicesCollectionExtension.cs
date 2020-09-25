using FunProject.Application.Customers.Data.Qeuries;
using FunProject.Persistence.Customers;
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
            services.AddTransient<IGetCustomersQuery, GetCustomersQuery>();
        }
    }
}
