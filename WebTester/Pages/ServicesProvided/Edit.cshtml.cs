using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebTester.Models.ServicesProvided;
using WebTester.Models.ServicesProvided.Enums;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.ServicesProvided
{
    public class EditModel : PageModel
    {
        private readonly IServiceProvidedRepository _repository;

        public EditModel(IServiceProvidedRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public ServiceProvided Service { get; set; } = new();

        public bool IsNew => Service.Id == 0;

        public List<SelectListItem> ServiceTypes { get; set; } = Enum.GetValues(typeof(Service_Type))
            .Cast<Service_Type>()
            .Select(e => new SelectListItem { Value = ((int)e).ToString(), Text = e.ToString() })
            .ToList();

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Service = _repository.GetService(id.Value);
                if (Service == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Service.Id == 0)
            {
                _repository.Add(Service);
            }
            else
            {
                _repository.Update(Service);
            }

            return RedirectToPage("/ServicesProvided/Index");
        }
    }
}
