using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.Organizations;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Pages.Organizations
{
    public class IndexModel(IOrganizationRepository organizationRepository) : PageModel
    {
        public IEnumerable<Organization>? organizations { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public void OnGet()
        {
            organizations = organizationRepository.Search(SearchTerm);
        }
    }
}
