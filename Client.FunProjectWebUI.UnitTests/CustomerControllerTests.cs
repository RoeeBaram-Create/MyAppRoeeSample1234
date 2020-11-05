using FluentNHibernate.Conventions.Inspections;
using FunProject.Application.Creations;
using FunProject.Application.CustomersModule.Dtos;
using FunProject.Application.CustomersModule.Services;
using FunProject.Application.CustomersModule.Services.Interfaces;
using FunProject.Application.Data.ActivityLogs.Query;
using FunProject.Application.Data.Customers.Command;
using FunProject.Application.Data.Customers.Query;
using FunProject.Domain.Logger;
using FunProject.Domain.Mapper;
using FunProjectWebApi.Controllers;
using Google.Rpc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;


namespace FunProject.WebApi.Tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private static object[] _emptyCustomersDtosList ={new object[] {new List<CustomerDto>()}};
        private CustomerController _customerController;
        private Mock<ICustomersService> _customersService;
        private Mock<ILoggerAdapter<CustomerController>> _logger;


        [SetUp]
        public void SetUp()
        {
            _customersService = new Mock<ICustomersService>();
            _logger = new Mock<ILoggerAdapter<CustomerController>>();
            _customerController = new CustomerController(_customersService.Object, _logger.Object);
           

        }

        [Test]
        public async Task CreateCustomer_ServerError_ReturnInternalServerError()
        {
            CustomerDto customerDto = new CustomerDto
            {
                FirstName = "Avi",
                LastName = "Cohen",
                Id = 1,
            };

            _customersService.Setup(cs => cs.CreateCustomer(customerDto)).Throws<Exception>();
            var result = await _customerController.CreateCustomer(customerDto) as ObjectResult;

            Assert.AreEqual(result.StatusCode, StatusCodes.Status500InternalServerError);
        }

        [Test]
        public async Task CreateCustomer_CustomerObjectPassedFromTheClientIsNull_ReturnBadRequest()
        {
            CustomerDto customerDto = null;

            var result = await _customerController.CreateCustomer(customerDto);

            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task CreateCustomer_WhenModelStateIsInValid_ReturnBadRequest()
        {
            _customerController.ModelState.AddModelError("FirstName", "Required");
            _customerController.ModelState.AddModelError("LastName", "Required");

            CustomerDto customerDto = new CustomerDto();

            var result = await _customerController.CreateCustomer(customerDto);

            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task CreateCustomer_CustomerCreationSucceeded_ReturnOkRequest()
        {
            CustomerDto customerDto = new CustomerDto
            {
                FirstName = "Avi",
                LastName = "Cohen",
                Id = 1,
            };

            var result = await _customerController.CreateCustomer(customerDto);

            Assert.That(result, Is.TypeOf<Microsoft.AspNetCore.Mvc.OkResult>());
        }

        [Test]
        public async Task DeleteCustomer_ServerError_ReturnInternalServerError()
        {
            CustomerDto customerDto = new CustomerDto
            {
                FirstName = "Avi",
                LastName = "Cohen",
                Id = 1,
            };

            _customersService.Setup(cs => cs.CreateCustomer(customerDto)).Throws<Exception>();
            var result = await _customerController.CreateCustomer(customerDto) as ObjectResult;

            Assert.AreEqual(result.StatusCode, StatusCodes.Status500InternalServerError);
        }


        [Test]
        public async Task DeleteCustomer_CustomerIdThatPassedFromTheClientIsNull_ReturnNotFoundRequest()
        {
            int? customerId = null;

            var result = await _customerController.DeleteCustomer(customerId);

            Assert.That(result, Is.TypeOf<NotFoundObjectResult>());
        }

        [Test]
        public async Task DeleteCustomer_CustomerDeletionSucceeded_ReturnOkRequest()
        {
            int? customerId = 1;

            var result = await _customerController.DeleteCustomer(customerId);

            Assert.That(result, Is.TypeOf<Microsoft.AspNetCore.Mvc.OkResult>());
        }

        [Test]
        public async Task GetCustomerDetails_ServerError_ReturnInternalServerError()
        {
            int? customerId = 1;

            _customersService.Setup(cs => cs.GetCustomer(customerId)).Throws<Exception>();
            var result = await _customerController.GetCustomerDetails(customerId);

            var objectResult = result.Result as ObjectResult;

            Assert.AreEqual(objectResult.StatusCode, StatusCodes.Status500InternalServerError);
        }

        [Test]
        public async Task GetCustomerDetails_CustomerIdPassedFromTheClientIsNull_ReturnNotFoundRequest()
        {
            int? customerId = null;

            var result = await _customerController.GetCustomerDetails(customerId);

            Assert.That(result.Result, Is.TypeOf<NotFoundObjectResult>());
        }

        [Test]
        public async Task GetCustomerDetails_CustomerNotExistInTheDataStorage_ReturnNotFoundRequest()
        {

            int? customerId = 1;

            _customersService.Setup(cs => cs.GetCustomer(customerId)).ReturnsAsync(() => null);

            var result = await _customerController.GetCustomerDetails(customerId);

            Assert.That(result.Result, Is.TypeOf<NotFoundObjectResult>());
        }

        [Test]
        public async Task GetCustomerDetails_GetCustomerSucceeded_ReturnOkRequestWithCustomerDtoContent()
        {
            int? customerId = 1;

            CustomerDto customerDto = new CustomerDto
            {
                FirstName = "Avi",
                LastName = "Cohen",
                Id = 1,
            };

            _customersService.Setup(cs => cs.GetCustomer(customerId)).ReturnsAsync(customerDto);

            var result = await _customerController.GetCustomerDetails(customerId);

            var objectResult = result.Result as ObjectResult;

            Assert.AreEqual(objectResult.Value, customerDto);

        }

        [Test]
        public async Task EditCustomer_ServerError_ReturnInternalServerError()
        {
            CustomerDto customerDto = new CustomerDto
            {
                FirstName = "Avi",
                LastName = "Cohen",
                Id = 1,
            };

            _customersService.Setup(cs => cs.EditCustomer(customerDto)).Throws<Exception>();
            var result = await _customerController.EditCustomer(customerDto) as ObjectResult;

            Assert.AreEqual(result.StatusCode, StatusCodes.Status500InternalServerError);
        }

        [Test]
        public async Task EditCustomer_CustomerObjectPassedFromTheClientIsNull_ReturnBadRequest()
        {
            CustomerDto customerDto = null;

            var result = await _customerController.EditCustomer(customerDto);

            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task EditCustomer_WhenModelStateIsInValid_ReturnBadRequest()
        {
            _customerController.ModelState.AddModelError("FirstName", "Required");
            _customerController.ModelState.AddModelError("LastName", "Required");

            CustomerDto customerDto = new CustomerDto();

            var result = await _customerController.EditCustomer(customerDto);

            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task EditCustomer_CustomerEditingSucceeded_ReturnOkRequest()
        {
            CustomerDto customerDto = new CustomerDto
            {
                FirstName = "Avi",
                LastName = "Cohen",
                Id = 1,
            };

            var result = await _customerController.EditCustomer(customerDto);

            Assert.That(result, Is.TypeOf<Microsoft.AspNetCore.Mvc.OkResult>());
        }


        [Test]
        public async Task GetAllCustomers_ServerError_ReturnInternalServerError()
        {
           

            _customersService.Setup(cs => cs.GetAllCustomers()).Throws<Exception>();
            var result = await _customerController.GetAllCustomers();

            var objectResult = result.Result as ObjectResult;

            Assert.AreEqual(objectResult.StatusCode, StatusCodes.Status500InternalServerError);
        }



        [Test]
        [TestCase(null)]
        [TestCaseSource("_emptyCustomersDtosList")]

        public async Task GetAllCustomers_CustomersNotExistInTheDataStorage_ReturnNotFoundRequest(IList<CustomerDto> customersDtos)
        {

            _customersService.Setup(cs => cs.GetAllCustomers()).ReturnsAsync(() => customersDtos);

            var result = await _customerController.GetAllCustomers();

            Assert.That(result.Result, Is.TypeOf<NotFoundObjectResult>());

        }

        
        [Test]
        public async Task GetAllCustomers_GetAllCustomerSucceeded_ReturnOkRequest()
        {

            List<CustomerDto> customerDtos = new List<CustomerDto>
            {
                new CustomerDto{
                FirstName = "Avi",
                LastName = "Cohen",
                Id = 1
                },

                 new CustomerDto{
                FirstName = "Guy",
                LastName = "Levi",
                Id = 2
                },

                  new CustomerDto{
                FirstName = "Sagi",
                LastName = "bechor",
                Id = 3
                }
            };

            _customersService.Setup(cs => cs.GetAllCustomers()).ReturnsAsync(customerDtos);

            var result = await _customerController.GetAllCustomers();

            var objectResult = result.Result as ObjectResult;

            Assert.AreEqual(objectResult.Value, customerDtos);

        }

    }
}
