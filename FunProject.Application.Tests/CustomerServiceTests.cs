using FunProject.Application.Creations;
using FunProject.Application.CustomersModule.Dtos;
using FunProject.Application.CustomersModule.Services;
using FunProject.Application.Data.ActivityLogs.Query;
using FunProject.Application.Data.Customers.Command;
using FunProject.Application.Data.Customers.Query;
using FunProject.Domain.Entities;
using FunProject.Domain.Logger;
using FunProject.Domain.Mapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunProject.Application.Tests
{
    [TestFixture]
    public class CustomerServiceTests
    {

        private CustomersService _customersService;
        private Mock<ICustomerById> _customerById;
        private Mock<IAllCustomers> _getAllCustomers;
        private Mock<ICreateCustomer> _createCustomer;
        private Mock<IDeleteCustomer> _deleteCustomer;
        private Mock<IEditCustomer> _editCustomer;
        private Mock<IMapperAdapter> _mapperAdapter;
        private Mock<ILoggerAdapter<CustomersService>> _logger;
        private Mock<IAllActivityLogs> _allActivityLogs;
        private Mock<IActiviryLogCreation> _activiryLogCreation;
        private CustomerDto _customerDto;
        private Customer _customerEntity;


       [SetUp]
        public void SetUp()
        {
            _customerDto = new CustomerDto
            {
                FirstName = "Avi",
                LastName = "Cohen",
                Id = 1
            };

            _customerEntity = new Customer
            {
                FirstName = "Avi",
                LastName = "Cohen",
                Id = 1
            };

            _customerById = new Mock<ICustomerById>();
            _getAllCustomers = new Mock<IAllCustomers>();
            _createCustomer = new Mock<ICreateCustomer>();
            _deleteCustomer = new Mock<IDeleteCustomer>();
            _editCustomer = new Mock<IEditCustomer>();
            _mapperAdapter = new Mock<IMapperAdapter>();
            _logger = new Mock<ILoggerAdapter<CustomersService>>();
            _allActivityLogs = new Mock<IAllActivityLogs>();
            _activiryLogCreation = new Mock<IActiviryLogCreation>();

            _customersService = new CustomersService(_customerById.Object,
                _getAllCustomers.Object,
                _createCustomer.Object,
                _deleteCustomer.Object,
                _editCustomer.Object,
                _mapperAdapter.Object,
                _logger.Object,
                _allActivityLogs.Object,
                _activiryLogCreation.Object);

        }


        [Test]
        public void CreateCustomer_ServerError_ReturnInternalServerError()
        {
            _mapperAdapter.Setup(ma => ma.Map<Customer>(_customerDto)).Returns(_customerEntity);

            _createCustomer.Setup(cs => cs.Create(_customerEntity)).Throws<Exception>();

            Assert.That(async() => await _customersService.CreateCustomer(_customerDto), Throws.Exception);

        }


        [Test]
        public async Task CreateCustomer_WhenCalled_CreateCustomerInDb()
        {
            _mapperAdapter.Setup(ma => ma.Map<Customer>(_customerDto)).Returns(_customerEntity);

            await _customersService.CreateCustomer(_customerDto);

            _createCustomer.Verify(s => s.Create(_customerEntity));
        }

        [Test]
        public void GetCustomer_ServerError_ReturnInternalServerError()
        {
            int? customerId = 1;

            _mapperAdapter.Setup(ma => ma.Map<CustomerDto>(_customerEntity)).Returns(_customerDto);

            _customerById.Setup(cbi => cbi.Get(customerId)).Throws<Exception>();

            Assert.That(async () => await _customersService.GetCustomer(customerId), Throws.Exception);

        }


        [Test]
        public async Task GetCustomer_WhenCalled_GetCustomerFromDb()
        {
            int? customerId = 1;

            _mapperAdapter.Setup(ma => ma.Map<CustomerDto>(_customerEntity)).Returns(_customerDto);

            await _customersService.GetCustomer(customerId);

            _customerById.Verify(s => s.Get(customerId));
        }

        [Test]
        public void GetAllCustomer_ServerError_ReturnInternalServerError()
        {
            
            List<CustomerDto> customerDtos = new List<CustomerDto> { _customerDto };

            _mapperAdapter.Setup(ma => ma.Map<IList<CustomerDto>>(_customerEntity)).Returns(customerDtos);

            _getAllCustomers.Setup(gac => gac.Get()).Throws<Exception>();

            Assert.That(async () => await _customersService.GetAllCustomers(), Throws.Exception);

        }

        [Test]
        public async Task GetAllCustomer_WhenCalled_GetAllCustomersFromDb()
        {
            List<CustomerDto> customerDtosList = new List<CustomerDto> { _customerDto };
            List<Customer> customerEntityList = new List<Customer> { _customerEntity };

            _mapperAdapter.Setup(ma => ma.Map<IList<CustomerDto>>(customerEntityList)).Returns(customerDtosList);

            _getAllCustomers.Setup(gac => gac.Get()).ReturnsAsync(customerEntityList);

            var result = await _customersService.GetAllCustomers();

            Assert.AreEqual(result, customerDtosList);
        }


        [Test]
        public void DeleteCustomer_ServerError_ReturnInternalServerError()
        {
            int? customerId = 1;

            _customerById.Setup(gac => gac.Get(customerId)).ReturnsAsync(_customerEntity);
            _deleteCustomer.Setup(dc => dc.Delete(_customerEntity)).Throws<Exception>();

            Assert.That(async () => await _customersService.DeleteCustomer(customerId), Throws.Exception);

        }


        [Test]
        public async Task DeleteCustomer_CostomerNotExistInTheDataStorage_CustomerNotDeleted()
        {
            int? customerId = 1;

            _customerById.Setup(gac => gac.Get(customerId)).ReturnsAsync(() => null);

            await _customersService.DeleteCustomer(customerId);

            _deleteCustomer.Verify(s => s.Delete(It.IsAny<Customer>()),Times.Never);

        }


        [Test]
        public async Task DeleteCustomer_CostomerExistInTheDataStorage_CustomerDeleted()
        {
            int? customerId = 1;

            _customerById.Setup(gac => gac.Get(customerId)).ReturnsAsync(_customerEntity);

            await _customersService.DeleteCustomer(customerId);

            _deleteCustomer.Verify(s => s.Delete(_customerEntity));

        }


        [Test]
        public void EditCustomer_ServerError_ReturnInternalServerError()
        {
            _mapperAdapter.Setup(ma => ma.Map<Customer>(_customerDto)).Returns(_customerEntity);

            _editCustomer.Setup(ec => ec.Edit(_customerEntity)).Throws<Exception>();

            Assert.That(async () => await _customersService.EditCustomer(_customerDto), Throws.Exception);

        }


        [Test]
        public async Task EditCustomer_WhenCalled_EditCustomerInDb()
        {
            _mapperAdapter.Setup(ma => ma.Map<Customer>(_customerDto)).Returns(_customerEntity);

            await _customersService.EditCustomer(_customerDto);

            _editCustomer.Verify(s => s.Edit(_customerEntity));
        }

    }
}
