using FunProject.Application.CustomersModule.Dtos;
using FunProject.Application.CustomersModule.Services.Interfaces;
using FunProject.Application.Data.Customers.Command;
using FunProject.Application.Data.Customers.Query;
using FunProject.Domain.Entities;
using FunProject.Domain.Logger;
using FunProject.Domain.Mapper;
using System;
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
        private readonly ILoggerAdapter<CustomersService> _logger;

        public CustomersService(
            ICustomerById customerById,
            IAllCustomers allCustomers, 
            ICreateCustomer createCustomer,
            IDeleteCustomer deleteCustomer,
            IMapperAdapter mapperAdapter,
            ILoggerAdapter<CustomersService> logger)
        {
            _customerById = customerById;
            _getAllCustomers = allCustomers;
            _createCustomer = createCustomer;
            _deleteCustomer = deleteCustomer;
            _mapperAdapter = mapperAdapter;
            _logger = logger;
        }

        public async Task CreateCustomer(CustomerDto customer)
        {
            _logger.LogInformation("Method CreateCustomer was hit...");
            try
            {
                await _createCustomer.Create(_mapperAdapter.Map<Customer>(customer));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Method CreateCustomer failed");
                throw;
            }
        }

        public async Task<CustomerDto> GetCustomer(int? id)
        {
            _logger.LogInformation("Method GetCustomer was hit...");
            try
            {
                return _mapperAdapter.Map<CustomerDto>(await _customerById.Get(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Method GetCustomer failed");
                throw;
            }
        }

        public async Task<IList<CustomerDto>> GetAllCustomers()
        {
            _logger.LogInformation("Method GetAllCustomers was hit...");
            try
            {
                return _mapperAdapter.Map<IList<CustomerDto>>(await _getAllCustomers.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Method GetAllCustomers failed");
                throw;
            }
        }

        public async Task DeleteCustomer(int? id)
        {
            _logger.LogInformation("Method DeleteCustomer was hit...");
            try
            {
                var customer = await _customerById.Get(id);
                if (customer != null)
                {
                    await _deleteCustomer.Delete(customer);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Mehtod DeleteCustomer failed");
                throw;
            }
        }
    }
}
