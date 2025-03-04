using WebTester.Models.Organizations;
using WebTester.Models.ServicesProvided;

namespace WebTester.Services.Organizations.Interfaces
{
    public interface IPurchasedServices
    {
        IEnumerable<PurchasedService> GetAllServices();

        //C.R.U.D

        PurchasedService Add(PurchasedService serviceToAdd);

        PurchasedService GetPurchasedService(int id);

        PurchasedService Update(PurchasedService serviceToUpdate);

        PurchasedService Delete(PurchasedService serviceToDelete); 
    }
}
