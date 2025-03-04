using Microsoft.EntityFrameworkCore; // Add this for .Include()
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Organizations;
using WebTester.Models.Tickets;
using WebTester.Models.Settings;
using WebTester.Services.Tickets.Interfaces;

namespace WebTester.Services.Tickets.Repositories
{
    public class SQLMasterSettingsRepository(AppDBContext context) : IMasterSettingsRepository
    {
        public MasterSettings Add(MasterSettings newSettings)
        {
            context.MasterSettings.Add(newSettings);
            context.SaveChanges();
            return newSettings;
        }

        public MasterSettings? Delete()
        {
            MasterSettings? setting = context.MasterSettings.Find(1);
            if (setting != null) {
                context.MasterSettings.Remove(setting);
                context.SaveChanges();
                    }
                return setting;
        }

        public MasterSettings? GetMasterSettings()
        {
            MasterSettings? setting = context.MasterSettings.FirstOrDefault(s => s.id == 1);
            return setting;
        }

        public MasterSettings Update(MasterSettings updatedSettings)
        {

            if (updatedSettings.id == 0)
            {
                return Add(updatedSettings);
                
            }
            else
            {
                var settings = context.MasterSettings.Attach(updatedSettings);
                settings.State = EntityState.Modified;
                context.SaveChanges();

                return updatedSettings;
            }
        }
    }
}

