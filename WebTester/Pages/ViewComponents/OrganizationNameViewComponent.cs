using Microsoft.AspNetCore.Mvc;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.ViewComponents
{
    public class OrganizationNameViewComponent : ViewComponent
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationNameViewComponent(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public IViewComponentResult Invoke(int? organizationId)
        {
            if (organizationId == null)
            {
                return Content("No Organization");
            }

            var organization = _organizationRepository.GetOrganization(organizationId.Value);
            return Content(organization?.Title ?? "Unknown Organization");
        }
    }
}
