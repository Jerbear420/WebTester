using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Organizations;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Services.Organizations.Repositories
{
    public class SQLDomainRepository : IDomainRepository
    {
        private readonly AppDBContext context;

        public SQLDomainRepository(AppDBContext context)
        {
            this.context = context;
        }
        public Domain Add(Domain newDomain)
        {
            context.Domains.Add(newDomain);
            context.SaveChanges();
            return newDomain; 
        }

        public Domain? Delete(int id)
        {
            Domain dom = Get(id);
            if (dom != null)
            {
                context.Domains.Remove(dom);
                context.SaveChanges();
            }
            return dom;
        }

        public Domain? Get(int id)
        {
            return context.Domains.Find(id);
        }

        public IEnumerable<Domain> GetAll()
        {
            return context.Domains;
        }

        public IEnumerable<Domain> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return GetAll();
            }
            var list = context.Domains.Where(d => d.Name.ToLower().Contains(searchTerm.ToLower()));
            return list;
        }

        public Domain Update(Domain updateDomain)
        {
            var dom = context.Domains.Attach(updateDomain);
            dom.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateDomain;
        }
    }
}
