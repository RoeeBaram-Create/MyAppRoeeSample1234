using FunProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.Customers.Services
{
    public interface ICustomersService
    {
        Task<IList<Customer>> GetCustomers();
    }
}