using FunProject.Application.Data.Customers.Command;
using FunProject.Domain.Entities;
using System.Threading.Tasks;

namespace FunProject.Persistence.Customers.Command
{
    public class CreateCustomer : ICreateCustomer
    {
        private readonly AppDbContext _appDbContext;

        public CreateCustomer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Customer customer)
        {
            _appDbContext.Customers.Add(customer);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
