using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Organizations;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Services.Organizations.Repositories
{
    public class SQLLocationRepository : ILocationRepository
    {
        private readonly AppDBContext context;

        public SQLLocationRepository(AppDBContext context)
        {
            this.context = context;
        }
        public Location Add(Location newLocation)
        {
            context.Add(newLocation);
            context.SaveChanges();
            return newLocation;
        }

        public Location? Delete(int id)
        {
            var loc = Get(id);
            if (loc != null)
            {
                context.Locations.Remove(loc);
                context.SaveChanges();
            }
            return loc;
        }

        public Location? Get(int id)
        {
            return context.Locations.Find(id);
        }

        public IEnumerable<Location> GetAll()
        {
            return context.Locations;
        }

        public IEnumerable<Location> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return GetAll();
            }
            var list = context.Locations.Where(l => l.Name.ToLower().Contains(searchTerm.ToLower()));
            return list;
        }

        public Location Update(Location updateLocation)
        {
            var loc = context.Locations.Attach(updateLocation);
            loc.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateLocation;
        }
    }
}
