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
        public async Task<ActionResult> AddCustomer(CustomerDto customer)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    string logMessage = $"CustomerController.CreateCustomer - {E_ErrorType.BadRequest.ToString()} - Request not valid. visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return BadRequest("CustomerController.CreateCustomer - Request is not valid");
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

        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    string logMessage = $"CustomerController.Delete - {E_ErrorType.BadRequest.ToString()} - Request is not valid (id==null). visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return BadRequest("CustomerController.CreateCustomer - Request is not valid (id=null)");
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

        public async Task<ActionResult> CustomerDetails(int? id)
        {

            try
            {
                if (id == null)
                {
                    string logMessage = $"CustomerController.CustomerDetails - {E_ErrorType.BadRequest.ToString()} - Request is not valid (id==null). visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return BadRequest("CustomerController.CustomerDetails - Request is not valid (id=null)");
                }

                CustomerDto customer = await _customersService.GetCustomer(id);

                if (customer == null)
                {
                    string logMessage = $"CustomerController.CustomerDetails - {E_ErrorType.DataNotFound.ToString()} - Customer id number {id} not found . visited at {DateTime.UtcNow.ToLongTimeString()}";
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


        public async Task<ActionResult> EditCustomer(CustomerDto customer)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    string logMessage = $"CustomerController.EditCustomer - {E_ErrorType.BadRequest.ToString()} - Request not valid. visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return BadRequest("CustomerController.CreateCustomer - Request is not valid");
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
                    string logMessage = $"CustomerController.GetAllCustomers - {E_ErrorType.DataNotFound.ToString()} - customers list are equals null or empty . visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return NotFound($"CustomerController.GetAllCustomers - Customers list are equals null or empty");
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
