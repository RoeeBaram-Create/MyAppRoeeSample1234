using FunProject.Application.CustomersModule.Dtos;
using FunProject.Application.CustomersModule.Services.Interfaces;
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
        private readonly ICustomerById _customerById;
        private readonly IAllCustomers _getAllCustomers;
        private readonly ICreateCustomer _createCustomer;
        private readonly IDeleteCustomer _deleteCustomer;
        private readonly IMapperAdapter _mapperAdapter;

        public CustomersService(
            ICustomerById customerById,
            IAllCustomers allCustomers, 
            ICreateCustomer createCustomer,
            IDeleteCustomer deleteCustomer,
            IMapperAdapter mapperAdapter)
        {
            _customerById = customerById;
            _getAllCustomers = allCustomers;
            _createCustomer = createCustomer;
            _deleteCustomer = deleteCustomer;
            _mapperAdapter = mapperAdapter;
        }

        public async Task CreateCustomer(CustomerDto customer) => 
            await _createCustomer.Create(_mapperAdapter.Map<Customer>(customer));

        public async Task<CustomerDto> GetCustomer(int? id) => 
            _mapperAdapter.Map<CustomerDto>(await _customerById.Get(id));

        public async Task<IList<CustomerDto>> GetAllCustomers() => 
            _mapperAdapter.Map<IList<CustomerDto>>(await _getAllCustomers.Get());

        public async Task DeleteCustomer(int? id)
        {
            var customer = await _customerById.Get(id);
            if (customer != null)
            {
                await _deleteCustomer.Delete(customer);
                
            }
        }
    }
}
