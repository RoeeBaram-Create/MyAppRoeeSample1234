using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunProject.Application.ActivityLogModule.Dtos;
using FunProject.Application.ActivityLogModule.Services.Interfaces;
using FunProject.Domain.Enums;
using FunProject.Domain.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FunProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        private readonly IActivityLogService _activityLogService;
        private readonly ILoggerAdapter<ActivityLogController> _logger;

        public ActivityLogController(IActivityLogService activityLogService, ILoggerAdapter<ActivityLogController> logger)
        {
            _activityLogService = activityLogService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityLogDto>>> Get()
        {
            try
            {
                IEnumerable<ActivityLogDto> ActivityLogs = await _activityLogService.GetAllActivityLogs();
               
                if (ActivityLogs == null || !ActivityLogs.Any())
                {
                    string logMessage = $"ActivityLogController.GetAllActivityLogs - {E_ErrorType.DataNotFound.ToString()} - activity logs are equals null or empty . visited at {DateTime.UtcNow.ToLongTimeString()}";
                    _logger.LogError(logMessage);
                    return NotFound($"ActivityLogController.GetAllActivityLogs - customers list are equals null or empty");
                }

                return Ok(ActivityLogs);
            }
            catch(Exception ex)
            {
                string logMessage = $"ActivityLogController.GetAllActivityLogs - Exception. visited at {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogError(ex, logMessage);
                return StatusCode(500, E_ErrorType.Exception.ToString());
            }
        }

    }
}
