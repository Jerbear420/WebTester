using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTester.Models.Organizations
{
    public class Employee
    {
        public int Id { get; set; }
     
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public required string LastName { get; set; }
        public string? DisplayName { get; set; }
        [Required(ErrorMessage = "Email is required")] 
        public required string PrimaryEmail { get; set; }
        //[Required(ErrorMessage = "Organization is Required")]
        public int? OrganizationId { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string? UserPrincipalName { get; set; }

        public int? MicrosoftId { get; set; }

        public string? Image { get; set; }

    }
}
