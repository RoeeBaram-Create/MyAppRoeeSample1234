using FunProject.Application.Data.Customers.Command;
using FunProject.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace FunProject.Persistence.Customers.Command
{
    public class EditCustomer : IEditCustomer
    {
        private readonly AppDbContext _appDbContext;

        public EditCustomer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Edit(Customer customer)
        {
            if (_appDbContext.Customers.Any(customer => customer.Id == customer.Id))
            {
                _appDbContext.Customers.Update(customer);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
