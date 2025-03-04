using Microsoft.EntityFrameworkCore; // Add this for .Include()
using WebTester.Services.Tickets.Interfaces;
using WebTester.Models.ServicesProvided;

namespace WebTester.Services.Tickets.Repositories
{
    public class SQLServiceProvidedRepository(AppDBContext context) : IServiceProvidedRepository
    {
        public ServiceProvided Add(ServiceProvided newService)
        {
            context.ServicesProvided.Add(newService);
            context.SaveChanges();
            return newService;
        }

        public ServiceProvided? Delete(int id)
        {
            ServiceProvided? service = context.ServicesProvided.Find(id);
            if (service != null) {
                context.ServicesProvided.Remove(service);
                context.SaveChanges();
                    }
                return service;
        }

        public IEnumerable<ServiceProvided>? GetAllServices()
        {
            return context.ServicesProvided;
        }

        public ServiceProvided? GetService(int id)
        {
            ServiceProvided? service = context.ServicesProvided.FirstOrDefault(s => s.Id == id);
            return service;
        }

        public ServiceProvided Update(ServiceProvided updatedService)
        {

            if (updatedService.Id == 0)
            {
                return Add(updatedService);
                
            }
            else
            {
                var service = context.ServicesProvided.Attach(updatedService);
                service.State = EntityState.Modified;
                context.SaveChanges();

                return updatedService;
            }
        }
    }
}

