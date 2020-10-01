using FunProject.Application.CustomersModule.Dtos;
using FunProject.Application.CustomersModule.Services.Interfacies;
using FunProject.Application.Data.Customers.Query;
using FunProject.Domain.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunProject.Application.CustomersModule.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IGetAllCustomers _getCustomersQuery;
        private readonly IMapperAdapter _mapperAdapter;

        public CustomersService(
            IGetAllCustomers getCustomersQuery, 
            IMapperAdapter mapperAdapter)
        {
            _getCustomersQuery = getCustomersQuery;
            _mapperAdapter = mapperAdapter;
        }

        public async Task<IList<CustomerDto>> GetCustomers() => 
            _mapperAdapter.Map<IList<CustomerDto>>(await _getCustomersQuery.Get());
    }
}
