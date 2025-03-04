using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Organizations;

namespace WebTester.Services.Organizations.Interfaces
{
    public interface ILocationRepository
    {
        IEnumerable<Location> Search(string searchTerm);

        IEnumerable<Location> GetAll();

        Location Update(Location updateLocation);
        Location Add(Location newLocation);
        Location? Delete(int id);
        Location? Get(int id);
    }
}
