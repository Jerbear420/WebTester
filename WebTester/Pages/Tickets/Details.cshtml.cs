using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 
using WebTester.Models.Tickets; 
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.Tickets
{
    public class DetailsModel(ITicketRepository ticketRepository) : PageModel
    {
        public Ticket? Ticket { get; private set; }

        public IActionResult OnGet(int id)
        {
            Ticket = ticketRepository.Get(id);
            if (Ticket == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}
