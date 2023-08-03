using Facade.Application.Models;
using Facade.Infrastructure.Payments.Adapters;

namespace Facade.Infrastructure.Payments;

public class PaymentSlipService : IPaymentService
{
    private readonly IExternalPaymentSlipService _externalService;

    public PaymentSlipService(IExternalPaymentSlipService externalService)
    {
        _externalService = externalService;
    }

    public object Process(OrderInputModel model)
    {
        var adapter = new PaymentSlipServiceAdapter(_externalService);

        var paymentSlipModel = adapter.GeneratePaymentSlip(model);

        return "Dados do Boleto";
    }
}