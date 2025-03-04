using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.Tickets;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.Tickets
{
    public class IndexModel(ITicketRepository ticketRepository) : PageModel
    {
        public IEnumerable<Ticket>? Tickets { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public void OnGet()
        {
            Tickets = ticketRepository.Search(SearchTerm);
        }
    }
}
