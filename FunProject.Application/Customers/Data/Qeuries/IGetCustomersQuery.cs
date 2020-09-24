using FunProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.Customers.Data.Qeuries
{
    public interface IGetCustomersQuery
    {
        Task<IList<Customer>> Get();
    }
}
