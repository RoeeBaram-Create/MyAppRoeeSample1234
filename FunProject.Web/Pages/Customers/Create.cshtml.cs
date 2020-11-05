using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FunProject.Application.CustomersModule.Dtos;
using FunProject.Application.CustomersModule.Services.Interfaces;

namespace FunProject.Web.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomersService _customersService;
        
        public CreateModel(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CustomerDto Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customersService.CreateCustomer(Customer);

            return RedirectToPage("./Index");
        }
    }
}
