using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Organizations;

namespace WebTester.Services.Organizations.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Search(string searchTerm);
        IEnumerable<Employee> GetAll();

        Employee? Get(int id);
        Employee Update(Employee updateEmployee);
        Employee Add(Employee newEmployee);
        Employee? Delete(int id);

        List<Employee> GetEmployeesByOrganization(int id);
    }
}
