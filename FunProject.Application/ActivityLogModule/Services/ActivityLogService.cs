using FunProject.Application.ActivityLogModule.Dtos;
using FunProject.Application.ActivityLogModule.Services.Interfaces;
using FunProject.Application.Data.ActivityLogs.Query;
using FunProject.Domain.Entities;
using FunProject.Domain.Logger;
using FunProject.Domain.Mapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.ActivityLogModule.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IAllActivityLogs _allActivityLogs;
        private readonly IMapperAdapter _mapperAdapter;
        private readonly ILoggerAdapter<ActivityLogService> _logger;

        public ActivityLogService(
            IAllActivityLogs allActivityLogs,
            IMapperAdapter mapperAdapter, 
            ILoggerAdapter<ActivityLogService> logger)
        {
            _allActivityLogs = allActivityLogs;
            _mapperAdapter = mapperAdapter;
            _logger = logger;
        }

        public async Task<IList<ActivityLogDto>> GetAllActivityLogs()
        {
            _logger.LogInformation("Method GetAllActivityLogs was hit...");
            try
            {
                return _mapperAdapter.Map<IList<ActivityLogDto>>(await _allActivityLogs.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Method GetAllActivityLogs failed");
                throw;
            }
        }

        public async Task AddActivityLog(ActivityLogDto activityLogDto)
        {
            _logger.LogInformation("Method AddActivityLog was hit...");
            try
            {
                ActivityLog activityLog = _mapperAdapter.Map<ActivityLog>(activityLogDto);
                await _allActivityLogs.Add(activityLog);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Method AddActivityLog failed");
                throw;
            }
        }
    }
}
