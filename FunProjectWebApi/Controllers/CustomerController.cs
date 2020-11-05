using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunProject.Application.CustomersModule.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FunProject.Application.CustomersModule.Dtos;
using Microsoft.Extensions.Logging;
using FunProject.Domain.Logger;
using FunProject.Domain.Enums;

namespace FunProjectWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomersService _customersService;

        private readonly ILoggerAdapter<CustomerController> _logger;

        public CustomerController(ICustomersService customersService, ILoggerAdapter<CustomerController> logger)
        {
            _customersService = customersService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerDto customer)
        {
            try
            {
                if (customer == null)
                {
                    string logMessage = $"CustomerController.CreateCustomer - {E_ErrorType.BadRequest.ToString()} - customer object sent from client is null. visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return BadRequest("CustomerController.CreateCustomer - customer object is null");
                }

                if (!ModelState.IsValid)
                {
                    string logMessage = $"CustomerController.CreateCustomer - {E_ErrorType.BadRequest.ToString()} - Invalid customer object sent from client. visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return BadRequest("CustomerController.CreateCustomer - Invalid customer object");
                }

                await _customersService.CreateCustomer(customer);

                return Ok();
            }
            catch (Exception ex)
            {
                string logMessage = $"CustomerController.CreateCustomer - Exception. visited at {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogError(ex, logMessage);
                return StatusCode(500, E_ErrorType.Exception.ToString());
            }

        }

        [HttpDelete("{id?}")]
        public async Task<ActionResult> DeleteCustomer(int? id)
        {
            try
            {
                if (id == null)
                {
                    string logMessage = $"CustomerController.Delete - {E_ErrorType.DataNotFound.ToString()} - The id sent from client is null. visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return NotFound("CustomerController.Delete - Data not found (id = null)");
                }

                await _customersService.DeleteCustomer(id);

                return Ok();
            }
            catch (Exception ex)
            {
                string logMessage = $"CustomerController.Delete - Exception. visited at {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogError(ex, logMessage);
                return StatusCode(500, E_ErrorType.Exception.ToString());
            }
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerDetails(int? id)
        {
            try
            {
                if (id == null)
                {
                    string logMessage = $"CustomerController.CustomerDetails - {E_ErrorType.DataNotFound.ToString()} - The id sent from client is null . visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return NotFound("CustomerController.CustomerDetails - Data not found (id=null)");
                }

                CustomerDto customer = await _customersService.GetCustomer(id);

                if (customer == null)
                {
                    string logMessage = $"CustomerController.CustomerDetails - {E_ErrorType.DataNotFound.ToString()} - Customer with the id number {id} not found in the data storage . visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return NotFound($"CustomerController.CustomerDetails - Customer id number {id} not found");
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                string logMessage = $"CustomerController.CustomerDetails - Exception. visited at {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogError(ex, logMessage);
                return StatusCode(500, E_ErrorType.Exception.ToString());
            }

        }

        [HttpPut]
        public async Task<ActionResult> EditCustomer(CustomerDto customer)
        {
            try
            {
                if (customer == null)
                {
                    string logMessage = $"CustomerController.EditCustomer - {E_ErrorType.BadRequest.ToString()} - customer object sent from client is null. visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return BadRequest("CustomerController.EditCustomer - customer object is null");
                }

                if (!ModelState.IsValid)
                {
                    string logMessage = $"CustomerController.EditCustomer - {E_ErrorType.BadRequest.ToString()} - Invalid customer object sent from client . visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return BadRequest("CustomerController.EditCustomer - Invalid customer object");
                }

                await _customersService.EditCustomer(customer);

                return Ok();
            }
            catch (Exception ex)
            {
                string logMessage = $"CustomerController.EditCustomer - Exception. visited at {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogError(ex, logMessage);
                return StatusCode(500, E_ErrorType.Exception.ToString());
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            try
            {
                IEnumerable<CustomerDto> customers = await _customersService.GetAllCustomers();

                if (customers == null || !customers.Any())
                {
                    string logMessage = $"CustomerController.GetAllCustomers - {E_ErrorType.DataNotFound.ToString()} - Customers not found in the data storage  . visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return NotFound($"CustomerController.GetAllCustomers - Customers not found in the data storage");
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                string logMessage = $"CustomerController.GetAllCustomers - Exception. visited at {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogError(ex, logMessage);
                return StatusCode(500, E_ErrorType.Exception.ToString());
            }
        }


    }
}
