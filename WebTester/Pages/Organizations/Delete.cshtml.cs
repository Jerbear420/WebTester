using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.Organizations;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Pages.Organizations
{
    public class DeleteModel(IOrganizationRepository organizationRepository) : PageModel
    {
        [BindProperty]
        public Organization? Organization { get; set; }

        public IActionResult OnGet(int id)
        {
            Organization = organizationRepository.GetOrganization(id);

            if (organizationRepository == null)
            {
                return RedirectToPage("/NotFound");
            } else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            Organization? deletedOrg = organizationRepository.Delete(Organization.Id);

            if (deletedOrg == null)
            {
                return RedirectToPage("/NotFound");

            } 
                return RedirectToPage("Index");
            

        }
    }


}
