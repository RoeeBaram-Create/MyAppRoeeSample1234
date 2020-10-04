using FunProject.Application.CustomersModule.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.CustomersModule.Services.Interfacies
{
    public interface ICustomersService
    {
        Task<IList<CustomerDto>> GetCustomers();

        Task CreateCustomer(CustomerDto customer);
    }
}