using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using WebTester.Models.Organizations;
using WebTester.Models.Tickets;
using WebTester.Services.Organizations.Interfaces;
using WebTester.Services.Organizations.Repositories;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.TicketNotes
{
    public class EditModel(ITicketNoteRepository TicketNoteRepository) : PageModel
    {
        [BindProperty]
        public WebTester.Models.Tickets.TicketNote? TicketNote { get; set; }
        public IEnumerable<Organization>? Organizations { get; set; }
         
        public List<SelectListItem>? techList;
        public List<SelectListItem>? endUserList;
         
          

        public IActionResult OnGet(int? id)
        { 

            if (id.HasValue)
            {
                TicketNote = TicketNoteRepository.GetTicketNote(id.Value);
            }
            else
            {
                TicketNote = new TicketNote() { };
            }
            if (TicketNote == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();

        }
         
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            { 

                if (TicketNote.Id > 0)
                {

                    TicketNote = TicketNoteRepository.Update(TicketNote);
                }
                else
                {


                    TicketNote = TicketNoteRepository.Add(TicketNote);
                }
                return RedirectToPage("Index");
            } 
            return Page();
        }


    }
}
