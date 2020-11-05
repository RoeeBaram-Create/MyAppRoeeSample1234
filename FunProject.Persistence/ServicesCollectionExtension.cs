using FunProject.Application.Creations;
using FunProject.Application.Data.ActivityLogs.Query;
using FunProject.Application.Data.Customers.Command;
using FunProject.Application.Data.Customers.Query;
using FunProject.Persistence.ActivityLogs.Query;
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
            services.AddTransient<ISampleData, SampleData>();
            services.AddTransient<ICustomerById, GetCustomer>();
            services.AddTransient<IAllCustomers, AllCustomers>();
            services.AddTransient<ICreateCustomer, CreateCustomer>();
            services.AddTransient<IDeleteCustomer, DeleteCustomer>();
            services.AddTransient<IEditCustomer, EditCustomer>();

            services.AddTransient<IActiviryLogCreation, ActiviryLogCreation>();

            services.AddTransient<IAllActivityLogs, AllActivityLogs>();
        }
    }
}
