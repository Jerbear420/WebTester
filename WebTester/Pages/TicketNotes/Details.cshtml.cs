using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 
using WebTester.Models.Tickets; 
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.TicketNotes
{
    public class DetailsModel(ITicketNoteRepository TicketNoteRepository) : PageModel
    {
        public WebTester.Models.Tickets.TicketNote? TicketNote { get; private set; }

        public IActionResult OnGet(int id)
        {
            TicketNote = TicketNoteRepository.GetTicketNote(id);
            if (TicketNote == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}
