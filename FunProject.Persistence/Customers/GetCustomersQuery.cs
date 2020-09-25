using FunProject.Application.Customers.Data.Qeuries;
using FunProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Persistence.Customers
{
    public class GetCustomersQuery : IGetCustomersQuery
    {
        private readonly AppDbContext _appDbContext;

        public GetCustomersQuery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public async Task<IList<Customer>> Get()
        {
            return await _appDbContext.Customers.ToListAsync();
        }
    }
}
