using FunProject.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.Data.ActivityLogs.Query
{
    public interface IAllActivityLogs
    {
        Task<IList<ActivityLog>> Get();
    }
}
