using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.Organizations;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Pages.Employees
{
    public class IndexModel(IEmployeeRepository employeeRepository) : PageModel
    {
        public IEnumerable<Employee>? Employees { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public void OnGet()
        {
            Employees = employeeRepository.Search(SearchTerm);
        }
    }
}
