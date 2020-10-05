using FunProject.Application.Data.Customers.Query;
using FunProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FunProject.Persistence.Customers.Query
{
    public class GetCustomer : ICustomerById
    {
        private readonly AppDbContext _appDbContext;

        public GetCustomer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Customer> Get(int? id)
        {
            return await _appDbContext.Customers.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
