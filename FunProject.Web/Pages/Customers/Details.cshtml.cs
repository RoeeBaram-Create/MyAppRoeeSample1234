using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FunProject.Application.CustomersModule.Dtos;
using FunProject.Application.CustomersModule.Services.Interfaces;

namespace FunProject.Web.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomersService _customersService;

        public DetailsModel(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public CustomerDto Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _customersService.GetCustomer(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
