using FunProject.Domain.Entities;
using System.Threading.Tasks;

namespace FunProject.Application.Data.Customers.Command
{
    public interface ICreateCustomer
    {
        Task Create(Customer customer);
    }
}
