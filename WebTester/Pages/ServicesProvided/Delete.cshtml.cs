using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.ServicesProvided;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.ServicesProvided
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceProvidedRepository _repository;

        public DeleteModel(IServiceProvidedRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public ServiceProvided? Service { get; set; }

        public IActionResult OnGet(int id)
        {
            Service = _repository.GetService(id);
            if (Service == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Service?.Id == null)
            {
                return NotFound();
            }

            _repository.Delete(Service.Id);
            return RedirectToPage("/ServicesProvided/Index");
        }
    }
}
