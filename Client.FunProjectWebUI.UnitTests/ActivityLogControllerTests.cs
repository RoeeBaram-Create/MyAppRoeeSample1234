using FunProject.Application.ActivityLogModule.Dtos;
using FunProject.Application.ActivityLogModule.Services.Interfaces;
using FunProject.Domain.Enums;
using FunProject.Domain.Logger;
using FunProjectWebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunProject.WebApi.Tests
{
    [TestFixture]
    public class ActivityLogControllerTests
    {
        private static object[] _emptyActivityLogDtoList = { new object[] { new List<ActivityLogDto>() } };
        private ActivityLogController _activityLogController;
        private Mock<IActivityLogService> _activityLogService;
        private Mock<ILoggerAdapter<ActivityLogController>> _logger;

        [SetUp]
        public void SetUp()
        {
            _activityLogService = new Mock<IActivityLogService>();
            _logger = new Mock<ILoggerAdapter<ActivityLogController>>();
            _activityLogController = new ActivityLogController(_activityLogService.Object, _logger.Object);
        }


        [Test]
        public async Task GetAllActivityLogs_ServerError_ReturnInternalServerError()
        {


            _activityLogService.Setup(als => als.GetAllActivityLogs()).Throws<Exception>();

            var result = await _activityLogController.GetAllActivityLogs();

            var objectResult = result.Result as ObjectResult;

            Assert.AreEqual(objectResult.StatusCode, StatusCodes.Status500InternalServerError);
        }



        [Test]
        [TestCase(null)]
        [TestCaseSource("_emptyActivityLogDtoList")]

        public async Task GetAllCustomers_CustomersNotExistInTheDataStorage_ReturnNotFoundRequest(IList<ActivityLogDto> activityDtos)
        {

            _activityLogService.Setup(als => als.GetAllActivityLogs()).ReturnsAsync(() => activityDtos);

            var result = await _activityLogController.GetAllActivityLogs();

            Assert.That(result.Result, Is.TypeOf<NotFoundObjectResult>());

        }


        [Test]
        public async Task GetAllCustomers_GetAllCustomerSucceeded_ReturnOkRequest()
        {

            List<ActivityLogDto> customerDtos = new List<ActivityLogDto>
            {
                new ActivityLogDto{
                  Id=1,
                  CustomerId=4,
                  FullName = "dani levi",
                  ActionType = ActionType.Create,
                  ActivityDate = new DateTime(2020,09,13),
                },

                new ActivityLogDto{
                  Id=2,
                  CustomerId=5,
                  FullName = "Avi Levi",
                  ActionType = ActionType.Update,
                  ActivityDate = new DateTime(2020,09,14),
                },

                new ActivityLogDto{
                  Id=3,
                  CustomerId=6,
                  FullName = "Ron Meir",
                  ActionType = ActionType.Delete,
                  ActivityDate = new DateTime(2020,09,15),
                }
            };

            _activityLogService.Setup(als => als.GetAllActivityLogs()).ReturnsAsync(customerDtos);

            var result = await _activityLogController.GetAllActivityLogs();

            var objectResult = result.Result as ObjectResult;

            Assert.AreEqual(objectResult.Value, customerDtos);

        }



    }
}
