using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 
using WebTester.Models.Tickets;
using WebTester.Services.Organizations.Interfaces;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.TicketNotes
{
    public class IndexModel(ITicketNoteRepository TicketNoteRepository) : PageModel
    {
        public IEnumerable<WebTester.Models.Tickets.TicketNote>? TicketNotes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public void OnGet()
        {
            TicketNotes = TicketNoteRepository.Search(SearchTerm);
        }
    }
}
