using WebTester.Models.ServicesProvided.Enums;

namespace WebTester.Models.ServicesProvided
{
    public class ServiceProvided
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string SKU { get; set; } 

        public float Customer_Cost { get; set; }
        public float Reseller_Cost { get; set; }

        public int Qbo_Id { get; set; }

        public Service_Type Type { get; set; }
    }
}
