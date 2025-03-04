using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTester.Models.Organizations
{
    public class Domain
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Domain Name is Required")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Organization is Required")]
        public required int OrganizationId { get; set; }
        [Required(ErrorMessage = "Domain Host is Required")]
        public required string DomainHost { get; set; }

        public DateTime? NextRenewalDate { get; set; }
         
    }
}
