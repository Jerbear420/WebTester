using WebTester.Models.Organizations;
using WebTester.Models.Organizations.Enums;
namespace WebTester.Services.Organizations.Interfaces
{
    public interface IOrganizationRepository
    {
        IEnumerable<Organization> Search(string searchTerm);
        IEnumerable<Organization> GetAllOrganizations();
        Organization? GetOrganization(int id);
        Organization Update(Organization updateOrganization);

        Organization Add(Organization newOrganization);
        Organization? Delete(int id);

        OrgHeadCount OrganizationCount();
    }
}
