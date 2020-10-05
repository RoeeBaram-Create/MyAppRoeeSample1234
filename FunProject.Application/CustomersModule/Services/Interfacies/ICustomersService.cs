using FunProject.Application.CustomersModule.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.CustomersModule.Services.Interfacies
{
    public interface ICustomersService
    {
        Task<IList<CustomerDto>> GetAllCustomers();
        Task CreateCustomer(CustomerDto customer);
        Task<CustomerDto> GetCustomer(int? id);
        Task DeleteCustomer(int? id);
    }
}