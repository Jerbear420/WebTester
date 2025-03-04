using System.ComponentModel.DataAnnotations;
using WebTester.Models.Tickets.Enums;

namespace WebTester.Models.Tickets
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ticket Name is Required")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Created { get; set; }
        = DateTime.Now;
        public DateTime? Updated { get; set; }
        = DateTime.Now;
        [Required(ErrorMessage = "Ticket Status is Required")]
        public required TicketStatus Status { get; set; }
       // public List<int>? TechAssigned { get; set; }
       // public List<int>? EndUserAssigned { get; set; }
        
        public int? OrganizationId { get; set; }
        
    }
}
