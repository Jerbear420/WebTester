using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 
using WebTester.Models.Tickets; 
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.Tickets
{
    public class DeleteModel(ITicketRepository ticketRepository) : PageModel
    {
        [BindProperty]
        public Ticket? Ticket { get; set; }

        public IActionResult OnGet(int id)
        {
            Ticket = ticketRepository.Get(id);

            if (ticketRepository == null)
            {
                return RedirectToPage("/NotFound");
            } else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            Ticket? deletedTkt = ticketRepository.Delete(Ticket.Id);

            if (deletedTkt == null)
            {
                return RedirectToPage("/NotFound");

            } 
                return RedirectToPage("Index");
            

        }
    }


}
