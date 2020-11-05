using FunProject.Application.ActivityLogModule.Dtos;
using FunProject.Application.ActivityLogModule.Services;
using FunProject.Application.Data.ActivityLogs.Query;
using FunProject.Domain.Entities;
using FunProject.Domain.Logger;
using FunProject.Domain.Mapper;
using FunProject.Persistence.ActivityLogs.Query;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunProject.Application.Tests
{
    [TestFixture]
    public class ActivityLogServiceTests
    {
        private ActivityLogService _activityLogService;
        private Mock<IAllActivityLogs> _allActivityLogs;
        private Mock<IMapperAdapter> _mapperAdapter;
        private Mock<ILoggerAdapter<ActivityLogService>> _logger;
        private ActivityLogDto _activityLogDto;
        public ActivityLog _activityLogEntity;


        [SetUp]
        public void SetUp()
        {
            _activityLogDto = new ActivityLogDto
            {
                Id = 1,
                CustomerId = 1234,
                FullName = "Avi Levi",
                ActionType = Domain.Enums.ActionType.Create,
                ActivityDate = new DateTime(2020, 10, 11)
            };

            _activityLogEntity = new ActivityLog
            {
                Id = 1,
                CustomerId = 1234,
                ActionType = Domain.Enums.ActionType.Create,
                ActivityDate = new DateTime(2020, 10, 11)
            };

            _allActivityLogs = new Mock<IAllActivityLogs>();
            _mapperAdapter = new Mock<IMapperAdapter>();
            _logger = new Mock<ILoggerAdapter<ActivityLogService>>();
            _activityLogService = new ActivityLogService(_allActivityLogs.Object, _mapperAdapter.Object, _logger.Object);
        }

        [Test]
        public void GetAllActivityLogs_ServerError_ReturnInternalServerError()
        {

            List<ActivityLogDto> activityLogList = new List<ActivityLogDto> { _activityLogDto };

            _mapperAdapter.Setup(ma => ma.Map<IList<ActivityLogDto>>(_activityLogEntity)).Returns(activityLogList);

            _allActivityLogs.Setup(gac => gac.Get()).Throws<Exception>();

            Assert.That(async () => await _activityLogService.GetAllActivityLogs(), Throws.Exception);

        }

        [Test]
        public async Task GetAllActivityLogs_WhenCalled_GetAllActivityFromDb()
        {
            List<ActivityLogDto> activityLogList = new List<ActivityLogDto> { _activityLogDto };
            List<ActivityLog> activityLogEntityList = new List<ActivityLog> { _activityLogEntity };

            _mapperAdapter.Setup(ma => ma.Map<IList<ActivityLogDto>>(activityLogEntityList)).Returns(activityLogList);

            _allActivityLogs.Setup(gac => gac.Get()).ReturnsAsync(activityLogEntityList);

            var result = await _activityLogService.GetAllActivityLogs();

            Assert.AreEqual(result, activityLogList);
        }

        [Test]
        public void AddActivityLog_ServerError_ReturnInternalServerError()
        {
            _mapperAdapter.Setup(ma => ma.Map<ActivityLog>(_activityLogDto)).Returns(_activityLogEntity);

            _allActivityLogs.Setup(cs => cs.Add(_activityLogEntity)).Throws<Exception>();

            Assert.That(async () => await _activityLogService.AddActivityLog(_activityLogDto), Throws.Exception);

        }

        [Test]
        public async Task AddActivityLog_WhenCalled_AddActivityLogToDb()
        {
            _mapperAdapter.Setup(ma => ma.Map<ActivityLog>(_activityLogDto)).Returns(_activityLogEntity);

            await _activityLogService.AddActivityLog(_activityLogDto);

            _allActivityLogs.Verify(s => s.Add(_activityLogEntity));
        }

    }
}
