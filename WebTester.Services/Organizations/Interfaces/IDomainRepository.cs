using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Organizations;

namespace WebTester.Services.Organizations.Interfaces
{
    public interface IDomainRepository
    {
        IEnumerable<Domain> Search(string searchTerm);
        IEnumerable<Domain> GetAll();

        Domain? Get(int id);
        Domain Update(Domain updateDomain);
        Domain? Delete(int id);
        Domain Add(Domain newDomain);
    }
}
