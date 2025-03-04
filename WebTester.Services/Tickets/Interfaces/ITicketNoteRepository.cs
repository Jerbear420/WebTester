using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Tickets;

namespace WebTester.Services.Tickets.Interfaces
{
    public interface ITicketNoteRepository
    {
        IEnumerable<TicketNote> Search(string searchTerm);
        IEnumerable<TicketNote> GetAll();

        TicketNote? GetTicketNote(int id);

        TicketNote Add(TicketNote newTicketNote);

        TicketNote Update(TicketNote updateTicketNote);

        TicketNote? Delete(int id);
        IEnumerable<TicketNote> GetNotesByTicketId(int ticketId);
    }
}
