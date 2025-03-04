using WebTester.Models.Organizations;
using WebTester.Models.Tickets;
using WebTester.Models.Settings;

namespace WebTester.Services.Tickets.Interfaces
{
    public interface IMasterSettingsRepository 
    {

        MasterSettings? GetMasterSettings();

        MasterSettings Update(MasterSettings updatedSettings);

        MasterSettings Add(MasterSettings newSettings);

        MasterSettings? Delete();

    }
}
