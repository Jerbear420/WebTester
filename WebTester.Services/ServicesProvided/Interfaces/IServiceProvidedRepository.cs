using WebTester.Models.ServicesProvided;

namespace WebTester.Services.Tickets.Interfaces
{
    public interface IServiceProvidedRepository 
    {

        ServiceProvided? GetService(int id);

        ServiceProvided Update(ServiceProvided updatedService);

        ServiceProvided Add(ServiceProvided newService);

        ServiceProvided? Delete(int id);

        IEnumerable<ServiceProvided>? GetAllServices();

    }
}
