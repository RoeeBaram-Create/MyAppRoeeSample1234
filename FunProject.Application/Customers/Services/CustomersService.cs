using FunProject.Application.Customers.Data.Qeuries;
using FunProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.Customers.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IGetCustomersQuery _getCustomersQuery;

        public CustomersService(IGetCustomersQuery getCustomersQuery)
        {
            _getCustomersQuery = getCustomersQuery;
        }

        public Task<IList<Customer>> GetCustomers()
        {
            var customers = _getCustomersQuery.Get();

            return customers;
        }
    }
}
