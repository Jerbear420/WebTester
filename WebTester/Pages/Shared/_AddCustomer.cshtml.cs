using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebTester.Pages.Shared
{
    public class AddCustomerModel : PageModel
    {
        [BindProperty]
        public string CompanyName { get; set; }

        [BindProperty]
        public string ContactName { get; set; }

        [BindProperty]
        public int Employees { get; set; }
        [BindProperty]
        public string IsActive { get; set; }

        [BindProperty]
        public bool Testing { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Console.WriteLine("Make a post test");

            Console.WriteLine(CompanyName);
            Console.WriteLine(ContactName);
            Console.WriteLine(Employees);
            Console.WriteLine(IsActive);
            Console.WriteLine(Testing);
            Console.WriteLine("B");



        }

        public void OnPostSubmit()
        {
            Console.WriteLine("Make a submit test");


        }
    }
}
