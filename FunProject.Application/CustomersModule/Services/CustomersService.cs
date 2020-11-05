using FunProject.Application.ActivityLogModule.Dtos;
using FunProject.Application.Creations;
using FunProject.Application.CustomersModule.Dtos;
using FunProject.Application.CustomersModule.Services.Interfaces;
using FunProject.Application.Data.ActivityLogs.Query;
using FunProject.Application.Data.Customers.Command;
using FunProject.Application.Data.Customers.Query;
using FunProject.Domain.Entities;
using FunProject.Domain.Enums;
using FunProject.Domain.Logger;
using FunProject.Domain.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FunProject.Application.CustomersModule.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomerById _customerById;
        private readonly IAllCustomers _getAllCustomers;
        private readonly ICreateCustomer _createCustomer;
        private readonly IDeleteCustomer _deleteCustomer;
        private readonly IEditCustomer _editCustomer;
        private readonly IMapperAdapter _mapperAdapter;
        private readonly ILoggerAdapter<CustomersService> _logger;
        private readonly IAllActivityLogs _allActivityLogs;
        private readonly IActiviryLogCreation _activiryLogCreation;


        public CustomersService(
            ICustomerById customerById,
            IAllCustomers allCustomers, 
            ICreateCustomer createCustomer,
            IDeleteCustomer deleteCustomer,
            IEditCustomer editCustomer,
            IMapperAdapter mapperAdapter,
            ILoggerAdapter<CustomersService> logger,
            IAllActivityLogs allActivityLogs,
            IActiviryLogCreation activiryLogCreation)
        {
            _customerById = customerById;
            _getAllCustomers = allCustomers;
            _createCustomer = createCustomer;
            _deleteCustomer = deleteCustomer;
            _mapperAdapter = mapperAdapter;
            _logger = logger;
            _editCustomer = editCustomer;
            _allActivityLogs = allActivityLogs;
            _activiryLogCreation = activiryLogCreation;

        }

        public async Task CreateCustomer(CustomerDto customer)
        {
            _logger.LogInformation("Method CreateCustomer was hit...");
            try
            {
                Customer customerEntity = _mapperAdapter.Map<Customer>(customer);
                await _createCustomer.Create(customerEntity);

                ActivityLog activityLog = _activiryLogCreation.CreateActivityLog(customerEntity, ActionType.Create);

               await _allActivityLogs.Add(activityLog);

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

                    ActivityLog activityLog = _activiryLogCreation.CreateActivityLog(customer, ActionType.Delete);

                    await _allActivityLogs.Add(activityLog);

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Mehtod DeleteCustomer failed");
                throw;
            }
        }

        public async Task EditCustomer(CustomerDto customer)
        {
            _logger.LogInformation("Method EditCustomer was hit...");
            try
            {
                Customer customerEntity = _mapperAdapter.Map<Customer>(customer);
                await _editCustomer.Edit(customerEntity);
                ActivityLog activityLog = _activiryLogCreation.CreateActivityLog(customerEntity, ActionType.Update);
                await _allActivityLogs.Add(activityLog);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Method CreateCustomer failed");
                throw;
            }

        }
    }
}
