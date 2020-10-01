using FunProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.Data.Customers.Query
{
    public interface IGetAllCustomers
    {
        Task<IList<Customer>> Get();
    }
}
