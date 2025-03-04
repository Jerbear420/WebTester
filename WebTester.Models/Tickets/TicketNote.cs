using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Tickets.Enums;

namespace WebTester.Models.Tickets
{
    public class TicketNote
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Name is Requried")]
        public string? Name { get; set; }
        //[Required(ErrorMessage = "Description is Required")]
        public string? Description { get; set; }
        //[Required(ErrorMessage = "Note Type is Reqruied")]
        public NoteType? Type { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public DateTime? Appointment {  get; set; }
        //[Required(ErrorMessage = "Ticket is Required")]
        public int? TicketId { get; set; }
    }
}
