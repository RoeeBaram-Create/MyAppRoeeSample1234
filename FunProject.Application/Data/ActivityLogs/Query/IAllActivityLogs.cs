using FunProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.Data.ActivityLogs.Query
{
    public interface IAllActivityLogs
    {
        Task<IList<ActivityLog>> Get();
        Task Add(ActivityLog activityLog);
    }
}
