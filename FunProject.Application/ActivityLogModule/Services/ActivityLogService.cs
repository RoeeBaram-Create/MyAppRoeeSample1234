using FunProject.Application.ActivityLogModule.Dtos;
using FunProject.Application.ActivityLogModule.Services.Interfaces;
using FunProject.Application.Data.ActivityLogs.Query;
using FunProject.Domain.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.ActivityLogModule.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IAllActivityLogs _allActivityLogs;
        private readonly IMapperAdapter _mapperAdapter;

        public ActivityLogService(IAllActivityLogs allActivityLogs,
            IMapperAdapter mapperAdapter)
        {
            _allActivityLogs = allActivityLogs;
            _mapperAdapter = mapperAdapter;
        }

        public async Task<IList<ActivityLogDto>> GetAllActivityLogs() =>
            _mapperAdapter.Map<IList<ActivityLogDto>>(await _allActivityLogs.Get());
    }
}
