using Facade.Application.Models;

namespace Facade.Infrastructure.Deliveries;

public interface IDeliveryService
{
    void Deliver(OrderInputModel model);
}