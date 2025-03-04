using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.Tickets;
using WebTester.Models.Tickets.Enums;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.Tickets
{
      [ValidateAntiForgeryToken] // Ensures Anti-Forgery validation
    //[AutoValidateAntiforgeryToken]
    //[IgnoreAntiforgeryToken]
    public class CreateTicketNoteModel(ITicketRepository ticketRepository, ITicketNoteRepository ticketNoteRepository) : PageModel
    {
        private readonly ITicketRepository _ticketRepository = ticketRepository;
        private readonly ITicketNoteRepository _ticketNoteRepository = ticketNoteRepository;
         
        public JsonResult OnGet()
        {
            return new JsonResult(new { message = "On Get!" });
        }


        public JsonResult OnPost([FromForm] int TicketId)
        {  
            var ticket = _ticketRepository.Get(TicketId);
            if (ticket == null)
            {
                return new JsonResult(new { message = "Ticket not found!" });
            }

            var newNote = new TicketNote
            {
                Name = "New Note",
                Description = "Auto-created note",
                Type = NoteType.Note,
                StartTime = DateTime.Now,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                TicketId = TicketId
            };

            _ticketNoteRepository.Add(newNote);

            return new JsonResult(new { message = "Ticket note created successfully!" });
        }
         
    }
}
