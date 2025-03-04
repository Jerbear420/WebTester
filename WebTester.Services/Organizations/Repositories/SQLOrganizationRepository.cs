using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Organizations;
using WebTester.Models.Organizations.Enums;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Services.Organizations.Repositories
{
    public class SQLOrganizationRepository : IOrganizationRepository
    {
        private readonly AppDBContext context;


        public SQLOrganizationRepository(AppDBContext context)
        {
            this.context = context;
        }
        public Organization Add(Organization newOrganization)
        {
            context.Organizations.Add(newOrganization);
            context.SaveChanges();
            return newOrganization;
        }

        public Organization? Delete(int id)
        {
            Organization org = context.Organizations.Find(id);
            if (org != null)
            {
                context.Organizations.Remove(org);
                context.SaveChanges();
            }
            return org;
        }

        public IEnumerable<Organization> GetAllOrganizations()
        {
            return context.Organizations;
        }

        public Organization? GetOrganization(int id)
        {
            return context.Organizations.Find(id);
            //SqlParameter sqlParameter = new SqlParameter("@Id", id);
            //return context.Organizations.FromSqlRaw<Organization>("spGetOrganizationById @Id", sqlParameter).ToList().FirstOrDefault(); // .Find(id);
            //return context.Organizations.FromSqlRaw<Organization>("spGetOrganizationById {0}", id).ToList().FirstOrDefault(); // .Find(id);
        }

        public OrgHeadCount OrganizationCount()
        {
            return new OrgHeadCount()
            {
                Count = context.Organizations.Count()
            };
        }

        public IEnumerable<Organization> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Organizations;
            }
            var list = context.Organizations.Where(o => o.Title.ToLower().Contains(searchTerm.ToLower()));
            return list; // || o.PrimaryDomain.Contains(searchTerm)
        }

        public Organization Update(Organization updateOrganization)
        {
            var org = context.Organizations.Attach(updateOrganization);
            org.State = EntityState.Modified;
            context.SaveChanges();
            return updateOrganization;
        }
    }
}
