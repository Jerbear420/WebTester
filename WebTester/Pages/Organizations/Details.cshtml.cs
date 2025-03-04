using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebTester.Models.Organizations;
using WebTester.Models.ServicesProvided;
using WebTester.Services.Organizations.Interfaces;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Pages.Organizations
{
    public class DetailsModel : PageModel
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IPurchasedServices _purchasedServices;
        private readonly IServiceProvidedRepository _serviceProvidedRepository;

        public DetailsModel(IOrganizationRepository organizationRepository,
                            IPurchasedServices purchasedServices,
                            IServiceProvidedRepository serviceProvidedRepository)
        {
            _organizationRepository = organizationRepository;
            _purchasedServices = purchasedServices;
            _serviceProvidedRepository = serviceProvidedRepository;
        }

        //Binding properties for display
        
        [BindProperty]
        public PurchasedService NewPurchasedService { get; set; } = new();
        public List<ServiceProvided>? ServicesProvided { get; set; } = [];
        //List items for display
        public List<PurchasedService> PurchasedServicesList { get; private set; } = new();
        public List<SelectListItem> ServiceOptionsList { get; private set; } = new();
        public Organization? Organization { get; private set; } = new();



        public IActionResult OnGet(int id)
        {
            Organization = _organizationRepository.GetOrganization(id);
            if (Organization == null)
            {
                return RedirectToPage("/NotFound");
            }

            PurchasedServicesList = _purchasedServices.GetAllServices()
                .Where(s => s.OrganizationId == id)
                .ToList();

            foreach (var purchase in PurchasedServicesList)
            {
                ServicesProvided?.Add(_serviceProvidedRepository.GetService(purchase.ServiceId));
            }

            ServiceOptionsList = _serviceProvidedRepository.GetAllServices()
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();

            return Page();
        }

        public IActionResult OnPostAddService()
        {
            Console.WriteLine("OnPostAddService called!");

            if (!ModelState.IsValid)
            {
                return Page();
            } 

            _purchasedServices.Add(NewPurchasedService);
             return RedirectToPage(new { id = NewPurchasedService.OrganizationId });
        }

        public ServiceProvided? GetService(int serviceId)
        {
            return ServicesProvided?.Find(s => s.Id == serviceId);
        }
    }
}