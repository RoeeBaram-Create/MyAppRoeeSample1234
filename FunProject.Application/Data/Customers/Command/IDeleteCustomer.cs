using FunProject.Domain.Entities;
using System.Threading.Tasks;

namespace FunProject.Application.Data.Customers.Command
{
    public interface IDeleteCustomer
    {
        Task Delete(Customer customer);
    }
}
