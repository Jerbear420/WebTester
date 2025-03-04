using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using WebTester.Models.Organizations;
using WebTester.Models.Tickets;
using WebTester.Services.Organizations.Interfaces;
using WebTester.Services.Organizations.Repositories;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.Tickets
{
    public class EditModel(ITicketRepository ticketRepository, IOrganizationRepository organizationRepository, IEmployeeRepository employeeRepository) : PageModel
    {
        [BindProperty]
        public Ticket? Ticket { get; set; }
        public IEnumerable<Organization>? Organizations { get; set; }

        public List<SelectListItem>? orgList;
        public List<SelectListItem>? techList;
        public List<SelectListItem>? endUserList;

        public List<int> EmployeeSelect { get; set; }

        [BindProperty]
        public int OrgSelect { get; set; }
        public int StatusSelect { get; set; }

        public IActionResult OnGet(int? id)
        {
            BuildListItems();

            if (id.HasValue)
            {
                Ticket = ticketRepository.Get(id.Value);
            }
            else
            {
                Ticket = new Ticket() { Name = "", Status = WebTester.Models.Tickets.Enums.TicketStatus.New };
            }
            if (Ticket == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();

        }

        private void BuildListItems()
        {
            orgList = new List<SelectListItem>();
            Organizations = organizationRepository.GetAllOrganizations();
            foreach (var org in Organizations)
            {
                orgList.Add(new SelectListItem(value: org.Id.ToString(), text: org.Title));
            }
            endUserList = new List<SelectListItem>();

        }
        public IActionResult OnGetEmployees(int orgId)
        {
            var employees = employeeRepository.GetEmployeesByOrganization(orgId)
                .Select(e => new { e.Id, DisplayName = e.DisplayName ?? $"{e.FirstName} {e.LastName}" });

            return new JsonResult(employees);
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (OrgSelect != 0)
                {
                    Ticket.OrganizationId = OrgSelect;
                }

                if (Ticket.Id > 0)
                {
                    
                    Ticket = ticketRepository.Update(Ticket);
                }
                else
                {


                    Ticket = ticketRepository.Add(Ticket);
                }
                return RedirectToPage("Index");
            }
            BuildListItems();
            return Page();
        }


    }
}
