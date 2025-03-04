using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.Tickets
{
    public class GetTicketNotesModel(ITicketNoteRepository TicketNoteRepository) : PageModel
    {
        public JsonResult OnGet(int ticketId)
        {
            var ticketNotes = TicketNoteRepository.GetNotesByTicketId(ticketId);

            var result = ticketNotes.Select(note => new
            {
                note.Id,
                note.Name,
                note.Description,
                Created = (DateTime)(note.Created).Value // ISO format for JS compatibility
            });

            return new JsonResult(result);
        }
    }
}
