using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTester.Models.Organizations;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Services.Organizations.Repositories
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext context;

        public SQLEmployeeRepository(AppDBContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee newEmployee)
        {
            context.Employees.Add(newEmployee);
            context.SaveChanges();
            return newEmployee;
        }

        public Employee? Delete(int id)
        {
            var emp = context.Employees.Find(id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
            }
            return emp;
        }

        public Employee? Get(int id)
        {
            return context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employees;
        }

        public List<Employee> GetEmployeesByOrganization(int id)
        {
            var list = context.Employees.Where(e => e.OrganizationId == id).ToList();
            return list;
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
           if (string.IsNullOrEmpty(searchTerm))
            {
                return GetAll();
            }
           var list = context.Employees.Where(e => e.FirstName.ToLower().Contains(searchTerm.ToLower()));
            return list;
        }

        public Employee Update(Employee updateEmployee)
        {
            var emp = context.Employees.Attach(updateEmployee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateEmployee;
        }
    }
}
