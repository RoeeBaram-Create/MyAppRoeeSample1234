using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FunProject.Domain.Entities;
using FunProject.Application.Customers.Services;

namespace FunProject.Web.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomersService _customersService;

        public IndexModel(ICustomersService costomersService)
        {
            _customersService = costomersService;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _customersService.GetCustomers();
        }
    }
}