using FunProject.Domain.Entities;
using FunProject.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace FunProject.Persistence
{
    public interface ISampleData { Task SeedDataAsync(); }

    public class SampleData : ISampleData, IDisposable
    {
        private readonly AppDbContext _appDbContext;

        public SampleData(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task SeedDataAsync()
        {
            _appDbContext.Customers.Add(new Customer
            {
                Id = 1,
                FirstName = "Donald",
                LastName = "Trump"
            });

            _appDbContext.ActivityLogs.Add(new ActivityLog
            {
                Id = 1,
                CustomerId = 1,
                ActivityDate = new DateTime(2016, 11, 9),
                ActionType = ActionType.Create,
            });

            _appDbContext.ActivityLogs.Add(new ActivityLog
            {
                Id = 2,
                CustomerId = 1,
                ActivityDate = new DateTime(2020, 11, 3),
                ActionType = ActionType.Update,
            });

            await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
