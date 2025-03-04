using WebTester.Models.Organizations;
using WebTester.Services.Organizations.Interfaces;

namespace WebTester.Services.Organizations.Repositories
{
    public class SQLPurchasedServiceRepository : IPurchasedServices
    {
        private readonly AppDBContext context;
        public SQLPurchasedServiceRepository(AppDBContext context)
        {
            this.context = context;    
        }
        public PurchasedService Add(PurchasedService serviceToAdd)
        {
            context.PurchasedService.Add(serviceToAdd);
            context.SaveChanges();
            return serviceToAdd;
        }

        public PurchasedService Delete(PurchasedService serviceToDelete)
        {
            context.PurchasedService.Remove(serviceToDelete);
            context.SaveChanges();
            return serviceToDelete;
        }

        public IEnumerable<PurchasedService> GetAllServices()
        {
            return context.PurchasedService;
        }

        public PurchasedService GetPurchasedService(int id)
        {
            return context.PurchasedService.Find(id);
        }

        public PurchasedService Update(PurchasedService serviceToUpdate)
        {
            var svc = context.PurchasedService.Attach(serviceToUpdate);
            svc.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return serviceToUpdate;
        }
    }
}
