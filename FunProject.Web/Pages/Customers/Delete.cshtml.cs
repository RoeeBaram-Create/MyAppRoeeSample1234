using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FunProject.Application.CustomersModule.Services.Interfaces;
using FunProject.Application.CustomersModule.Dtos;

namespace FunProject.Web.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomersService _customersService;

        public DeleteModel(ICustomersService customersService)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _customersService.DeleteCustomer(id);

            return RedirectToPage("./Index");
        }
    }
}
