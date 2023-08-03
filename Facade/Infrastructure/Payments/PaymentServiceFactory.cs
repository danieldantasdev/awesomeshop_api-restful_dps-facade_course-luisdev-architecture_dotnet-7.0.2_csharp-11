using Facade.Core.Enums;
using Facade.Infrastructure.Integrations;
using Facade.Infrastructure.Payments.Decorators;

namespace Facade.Infrastructure.Payments;

public class PaymentServiceFactory : IPaymentServiceFactory
{
    private readonly CreditCardService _creditCardService;
    private readonly PaymentSlipService _paymentSlipService;
    private readonly ICoreCrmIntegrationService _crmService;

    public PaymentServiceFactory(
        CreditCardService creditCardService,
        PaymentSlipService paymentSlipService,
        ICoreCrmIntegrationService crmService
    )
    {
        _creditCardService = creditCardService;
        _paymentSlipService = paymentSlipService;
        _crmService = crmService;
    }

    public IPaymentService GetService(PaymentMethod paymentMethod)
    {
        IPaymentService paymentService;

        switch (paymentMethod)
        {
            case PaymentMethod.CreditCard:
                paymentService = _creditCardService;

                break;
            case PaymentMethod.PaymentSlip:
                paymentService = _paymentSlipService;

                break;
            default:
                throw new InvalidOperationException();
        }

        return new PaymentServiceDecorator(paymentService, _crmService);
    }
}