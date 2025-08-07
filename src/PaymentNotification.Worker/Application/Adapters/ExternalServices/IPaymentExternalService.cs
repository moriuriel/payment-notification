using PaymentProcessor.Worker.Application.Adapters.ExternalServices.Payment;
using PaymentProcessor.Worker.Application.Shared;

namespace PaymentProcessor.Worker.Application.Adapters.ExternalServices;

public interface IPaymentExternalService
{
  Task<ResultT<IEnumerable<PaymentResponse>>> GetPaymentsAsync(CancellationToken cancellationToken); 
}
