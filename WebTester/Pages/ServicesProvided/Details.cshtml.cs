using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.ServicesProvided;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.ServicesProvided
{
    public class DetailsModel : PageModel
    {
        private readonly IServiceProvidedRepository _repository;

        public DetailsModel(IServiceProvidedRepository repository)
        {
            _repository = repository;
        }

        public ServiceProvided? Service { get; private set; }

        public IActionResult OnGet(int id)
        {
            Service = _repository.GetService(id);
            if (Service == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
