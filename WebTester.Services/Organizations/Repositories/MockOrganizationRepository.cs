using Microsoft.Data.SqlClient;
using WebTester.Models.Organizations;
using WebTester.Models.Organizations.Enums;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Services.Organizations.Repositories
{
    public class MockOrganizationRepository : IOrganizationRepository
    {
        private List<Organization> _organizationList;

        public MockOrganizationRepository()
        {
        }

        private void nothing()
        {

            _organizationList = new List<Organization>();
            SqlConnection cnn;
            string connectionString = @"Server=localhost\sqlexpress;Database=mspcrm2025;Trusted_Connection=True;Connect Timeout=30;TrustServerCertificate=True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Organizations", cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Title"].ToString());
                    _organizationList.Add(new Organization { Title = reader["Title"].ToString(), Description = reader["Description"].ToString(), Id = (int)reader["SP_ID"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
            }
            cnn.Close();
        }

        public Organization Add(Organization newOrganization)
        {
            newOrganization.Id = _organizationList.Max(o => o.Id) + 1;
            _organizationList.Add(newOrganization);
            return newOrganization;
        }

        public Organization Delete(int id)
        {
            Organization RemoveOrg = _organizationList.FirstOrDefault(o => o.Id == id);
            if (RemoveOrg != null)
            {
                _organizationList.Remove(RemoveOrg);

            }
            return RemoveOrg;
        }

        public IEnumerable<Organization> GetAllOrganizations()
        {
            return _organizationList;
        }

        public Organization GetOrganization(int id)
        {
            return _organizationList.FirstOrDefault(o => o.Id == id);
        }

        public OrgHeadCount OrganizationCount()
        {
            return new OrgHeadCount()
            {
                Count = _organizationList.Count()
            };
        }

        public IEnumerable<Organization> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _organizationList;
            }
            var list = _organizationList.Where(o => o.Title.ToLower().Contains(searchTerm.ToLower()));
            return list; // || o.PrimaryDomain.Contains(searchTerm)

        }

        public Organization Update(Organization updateOrganization)
        {
            Organization org = _organizationList.FirstOrDefault(o => o.Id == updateOrganization.Id);

            if (org != null)
            {
                org.Title = updateOrganization.Title;
                org.Description = updateOrganization.Description;
                org.Image = updateOrganization.Image;

            }

            return org;
        }
    }
}
