using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FunProject.Domain.Entities;
using FunProject.Application.Customers.Services;

namespace FunProject.Web.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Persistence.AppDbContext _context;
        private readonly ICustomersService _costomersService;

        public IndexModel(Persistence.AppDbContext context, ICustomersService costomersService)
        {
            _context = context;
            _costomersService = costomersService;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
            Customer = await _costomersService.GetCustomers();
        }
    }
}
