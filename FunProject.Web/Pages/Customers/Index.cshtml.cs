using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FunProject.Application.CustomersModule.Services.Interfaces;
using FunProject.Application.CustomersModule.Dtos;

namespace FunProject.Web.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomersService _customersService;

        public IndexModel(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public IList<CustomerDto> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _customersService.GetAllCustomers();
        }
    }
}