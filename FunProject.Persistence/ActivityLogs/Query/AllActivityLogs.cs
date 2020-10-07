using FunProject.Application.Data.ActivityLogs.Query;
using FunProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunProject.Persistence.ActivityLogs.Query
{
    public class AllActivityLogs : IAllActivityLogs
    {
        private readonly AppDbContext _appDbContext;

        public AllActivityLogs(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IList<ActivityLog>> Get()
        {
            return await _appDbContext.ActivityLogs
                .Include(i => i.Customer)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
    }
}
