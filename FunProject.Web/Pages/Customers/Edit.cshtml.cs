using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FunProject.Application.CustomersModule.Services.Interfacies;
using FunProject.Application.CustomersModule.Dtos;

namespace FunProject.Web.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomersService _customersService;

        public EditModel(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Task 1.
            // Implement Update Customer logic in the same manner as all other actions (see Create, Delete pages)
            // Model of this Page is CustmerDto and NOT Customer entity -> need mapping

            return RedirectToPage("./Index");
        }
    }
}
