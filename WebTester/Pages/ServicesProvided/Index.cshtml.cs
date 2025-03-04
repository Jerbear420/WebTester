using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.ServicesProvided;
using WebTester.Services.Tickets.Interfaces;
using System.Collections.Generic;

namespace WebTester.Pages.ServicesProvided
{
    public class IndexModel(IServiceProvidedRepository servicesRepository) : PageModel
    {
        public List<ServiceProvided>? Services { get; set; }

        public void OnGet()
        {
            // Fetch all services
            Services = servicesRepository.GetAllServices()?.ToList() ?? new List<ServiceProvided>();
        }
    }
}
