using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.Organizations;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Pages.Employees
{
    public class DetailsModel(IEmployeeRepository EmployeeRepository) : PageModel
    {
        public Employee? Employee { get; private set; }

        public IActionResult OnGet(int id)
        {
            Employee = EmployeeRepository.Get(id);
            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}
