using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTester.Models.Organizations
{
    public class Location
    {
        public int Id {  get; set; }
        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }
        public string? Description { get; set; }

        public string? StreetAddress {  get; set; }
        public string? StreetAddress2 { get; set; }
        public string? City { get; set; } = string.Empty;
        public string? State { get; set; } = string.Empty;
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? PostalCode { get; set; }

        public int OrganizationId { get; set; }

    }
}
