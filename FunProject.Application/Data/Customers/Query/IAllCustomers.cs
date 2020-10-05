using FunProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.Data.Customers.Query
{
    public interface IAllCustomers
    {
        Task<IList<Customer>> Get();
    }
}
