using Microsoft.EntityFrameworkCore; // Add this for .Include()
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Organizations;
using WebTester.Models.Tickets;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Services.Tickets.Repositories
{
    public class SQLTicketRepository(AppDBContext context) : ITicketRepository
    {
        public Ticket Add(Ticket newTicket)
        {
            context.Tickets.Add(newTicket);
            context.SaveChanges();
            return newTicket;
        }

        public Ticket? Delete(int id)
        {
            Ticket? tkt = context.Tickets.Find(id);
            if (tkt != null)
            {
                context.Tickets.Remove(tkt);
                context.SaveChanges();
            }
            return tkt;
        }

        public Ticket? Get(int id)
        {
            return context.Tickets
                .FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return context.Tickets
                .ToList();
        }

        public IEnumerable<Ticket> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Tickets.ToList();
            }

            return context.Tickets
                .Where(t => t.Name.ToLower().Contains(searchTerm.ToLower()))
                .ToList();
        }

        public Ticket Update(Ticket updateTicket)
        {
            var tkt = context.Tickets.Attach(updateTicket);
            tkt.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateTicket;
        }
    }
}
