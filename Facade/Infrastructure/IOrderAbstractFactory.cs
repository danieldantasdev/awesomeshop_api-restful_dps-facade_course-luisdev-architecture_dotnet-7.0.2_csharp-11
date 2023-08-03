using Facade.Core.Enums;
using Facade.Infrastructure.Deliveries;
using Facade.Infrastructure.Payments;

namespace Facade.Infrastructure;

public interface IOrderAbstractFactory
{
    IPaymentService GetPaymentService(PaymentMethod method);
    IDeliveryService GetDeliveryService();
}