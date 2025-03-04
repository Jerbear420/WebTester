using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Organizations;

namespace WebTester.Models.MSP
{
    public class Technician
    {
        public int Id { get; set; }
        
        public int OrganizationId { get; set; }

        public int EmployeeId { get; set; }

        public int TeirLevel { get; set; }


    }
}
