using WebTester.Models.Organizations;
using WebTester.Models.Tickets;

namespace WebTester.Services.Tickets.Interfaces
{
    public interface ITicketRepository 
    {
        IEnumerable<Ticket>? Search(string searchTerm);

        IEnumerable<Ticket> GetAllTickets();

        Ticket? Get(int id);

        Ticket Update(Ticket updateTicket);

        Ticket Add(Ticket newTicket);

        Ticket? Delete(int id); 

    }
}
