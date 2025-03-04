using WebTester.Models.Organizations;

namespace WebTester.Models.Settings
{
    public class MasterSettings
    {

        public int id { get; set; }

        public string? Send_As { get; set; }

        public int OrganizationId { get; set; }
    }
}
