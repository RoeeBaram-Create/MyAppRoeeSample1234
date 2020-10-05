using FunProject.Application.ActivityLogModule.Dtos;
using FunProject.Application.ActivityLogModule.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Web.Pages.ActivityLog
{
    public class IndexModel : PageModel
    {
        private readonly IActivityLogService _activityLogService;

        public IndexModel(IActivityLogService activityLogService)
        {
            _activityLogService = activityLogService;
        }

        public IList<ActivityLogDto> ActivityLogs;

        public async Task OnGetAsync()
        {
            ActivityLogs = await _activityLogService.GetAllActivityLogs();
        }
    }
}
