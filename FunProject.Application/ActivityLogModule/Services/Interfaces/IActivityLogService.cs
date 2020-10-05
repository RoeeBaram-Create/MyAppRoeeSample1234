using FunProject.Application.ActivityLogModule.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.ActivityLogModule.Services.Interfaces
{
    public interface IActivityLogService
    {
        Task<IList<ActivityLogDto>> GetAllActivityLogs();
    }
}
