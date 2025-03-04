using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTester.Models.Tickets.Enums
{
    public enum TicketStatus
    {
        Unknown = 0,
        New = 1,
        Assigned = 2,
        InProgress = 3,
        Completed = 4,
        Billed = 5
    }
}
