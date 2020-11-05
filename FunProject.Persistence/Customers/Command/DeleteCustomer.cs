using FunProject.Application.Data.Customers.Command;
using FunProject.Domain.Entities;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FunProject.Persistence.Customers.Command
{
    public class DeleteCustomer : IDeleteCustomer
    {
        private readonly AppDbContext _appDbContext;

        public DeleteCustomer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Delete(Customer customer)
        {
            _appDbContext.Customers.Remove(customer);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
