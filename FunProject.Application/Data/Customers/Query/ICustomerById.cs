using FunProject.Domain.Entities;
using System.Threading.Tasks;

namespace FunProject.Application.Data.Customers.Query
{
    public interface ICustomerById
    {
        Task<Customer> Get(int? id);
    }
}
