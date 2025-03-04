using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.Organizations;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Pages.Employees
{
    public class DeleteModel(IEmployeeRepository EmployeeRepository) : PageModel
    {
        [BindProperty]
        public Employee? Employee { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = EmployeeRepository.Get(id);

            if (EmployeeRepository == null)
            {
                return RedirectToPage("/NotFound");
            } else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            Employee? deletedUser = EmployeeRepository.Delete(Employee.Id);

            if (deletedUser == null)
            {
                return RedirectToPage("/NotFound");

            } 
                return RedirectToPage("Index");
            

        }
    }


}
