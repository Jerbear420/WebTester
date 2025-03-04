using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Tickets;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Services.Tickets.Repositories
{
    public class SQLTicketNoteRepository : ITicketNoteRepository
    {
        private readonly AppDBContext context;

        public SQLTicketNoteRepository(AppDBContext context)
        {
            this.context = context;
        }
        public TicketNote Add(TicketNote newTicketNote)
        {
            context.TicketNotes.Add(newTicketNote);
            context.SaveChanges();
            return newTicketNote;
        }

        public TicketNote? Delete(int id)
        {
            TicketNote? note = GetTicketNote(id);
            if (note != null)
            {
                context.TicketNotes.Remove(note);
                context.SaveChanges();
            }
            return note;

        }

        public IEnumerable<TicketNote> GetAll()
        {
            return context.TicketNotes;
        }

        public IEnumerable<TicketNote> GetNotesByTicketId(int ticketId)
        {

            SqlParameter sqlParameter = new SqlParameter("@TicketId", ticketId);
            return context.TicketNotes.FromSqlRaw<TicketNote>("GetTicketNotesByTicketId @TicketId", sqlParameter).AsEnumerable().ToList();
            
        }

        public TicketNote? GetTicketNote(int id)
        {
            return context.TicketNotes.Find(id);
            
        }

        public IEnumerable<TicketNote> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return GetAll();
            }
            var list = context.TicketNotes.Where(n => n.Name.ToLower().Contains(searchTerm.ToLower()));
            return list;
        }

        public TicketNote Update(TicketNote updateTicketNote)
        {
            var note = context.TicketNotes.Attach(updateTicketNote);
            note.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateTicketNote;
        }
    }
}
