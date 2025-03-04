using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 
using WebTester.Models.Tickets; 
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.TicketNotes
{
    public class DeleteModel(ITicketNoteRepository TicketNoteRepository) : PageModel
    {
        [BindProperty]
        public WebTester.Models.Tickets.TicketNote? TicketNote { get; set; }

        public IActionResult OnGet(int id)
        {
            TicketNote = TicketNoteRepository.GetTicketNote(id);

            if (TicketNoteRepository == null)
            {
                return RedirectToPage("/NotFound");
            } else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            WebTester.Models.Tickets.TicketNote? deletedTkt = TicketNoteRepository.Delete(TicketNote.Id);

            if (deletedTkt == null)
            {
                return RedirectToPage("/NotFound");

            } 
                return RedirectToPage("Index");
            

        }
    }


}
