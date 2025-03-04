using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.Tickets;
using WebTester.Services.Tickets.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace WebTester.Pages.TicketNotes
{
    public class MyActiveNotesModel(ITicketNoteRepository ticketNoteRepository) : PageModel
    {
        private readonly ITicketNoteRepository _ticketNoteRepository = ticketNoteRepository;

        public JsonResult OnGet()
        {
            // Fetch ticket notes that have a StartTime but no EndTime (Active Notes)
            var activeNotes = _ticketNoteRepository.GetAll();

            return new JsonResult(activeNotes);
        }
    }
}
