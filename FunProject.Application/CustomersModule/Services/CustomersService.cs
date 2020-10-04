using FunProject.Application.CustomersModule.Dtos;
using FunProject.Application.CustomersModule.Services.Interfacies;
using FunProject.Application.Data.Customers.Command;
using FunProject.Application.Data.Customers.Query;
using FunProject.Domain.Entities;
using FunProject.Domain.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.CustomersModule.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IGetAllCustomers _getCustomersQuery;
        private readonly ICreateCustomer _createCustomer;
        private readonly IMapperAdapter _mapperAdapter;

        public CustomersService(
            IGetAllCustomers getCustomersQuery, 
            ICreateCustomer createCustomer,
            IMapperAdapter mapperAdapter)
        {
            _getCustomersQuery = getCustomersQuery;
            _createCustomer = createCustomer;
            _mapperAdapter = mapperAdapter;
        }

        public async Task CreateCustomer(CustomerDto customer) => 
            await _createCustomer.Create(_mapperAdapter.Map<Customer>(customer));

        public async Task<IList<CustomerDto>> GetCustomers() => 
            _mapperAdapter.Map<IList<CustomerDto>>(await _getCustomersQuery.Get());
    }
}
