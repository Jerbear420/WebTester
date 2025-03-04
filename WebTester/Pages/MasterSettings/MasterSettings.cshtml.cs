using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTester.Models.Organizations;
using WebTester.Services.Tickets.Interfaces;
using WebTester.Models.Settings;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Pages.MasterSettings
{
    public class MasterSettingsModel : PageModel
    {
        private readonly IMasterSettingsRepository _settingsRepository;
        private readonly IOrganizationRepository _organizationRepository;

        [BindProperty] // Bind only the ID, not the full object
        public int OrganizationId { get; set; }

        [BindProperty] // Bind only the ID, not the full object
        public string? SendAs { get; set; }


        public WebTester.Models.Settings.MasterSettings MasterSettings { get; set; }

        public List<Organization> Organizations { get; set; }

        public MasterSettingsModel(IMasterSettingsRepository settingsRepository, IOrganizationRepository organizationRepository)
        {
            _settingsRepository = settingsRepository;
            _organizationRepository = organizationRepository;
        }

        public void OnGet()
        {
            Populate_Organization_List();
            // Preselect the current organization if set
            OrganizationId = MasterSettings.OrganizationId;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Populate_Organization_List();
            // Fetch the full Organization entity from the database
              
            if (OrganizationId == 0)
            {
                ModelState.AddModelError("OrganizationId", "Invalid organization selected.");
                return Page();
            }
            Organization selectedOrganization = _organizationRepository.GetOrganization(OrganizationId);
            // Assign organization and update settings
            MasterSettings.OrganizationId = selectedOrganization.Id;
            MasterSettings.Send_As = SendAs;
            _settingsRepository.Update(MasterSettings);

            TempData["Message"] = "Settings updated successfully!";
            return RedirectToPage();
        }

        public void Populate_Organization_List()
        {

            // Load master settings
            MasterSettings = _settingsRepository.GetMasterSettings() ?? new WebTester.Models.Settings.MasterSettings();

            if (MasterSettings.id != 0) 
            {
                SendAs = MasterSettings.Send_As;
                OrganizationId = MasterSettings.id;
            }

            // Populate dropdown list
            Organizations = _organizationRepository.GetAllOrganizations().ToList();

        }
    }
}
