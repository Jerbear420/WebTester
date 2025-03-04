using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Organizations;
using WebTester.Models.Tickets;
using WebTester.Models.Settings;
using WebTester.Models.ServicesProvided;

namespace WebTester.Services
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        { 
            
        }
         
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<TicketNote> TicketNotes { get; set; }

        public DbSet<Domain> Domains { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<MasterSettings> MasterSettings { get; set; }

        public DbSet<ServiceProvided> ServicesProvided { get; set; }
        public DbSet<PurchasedService> PurchasedService { get; set; }

}
}
