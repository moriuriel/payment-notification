using System;
using PaymentProcessor.Worker.Application.Adapters.ExternalServices;

namespace PaymentProcessor.Worker.Application.Handlers.NotifyPayment;

internal sealed class NotifyPaymentHandler(IPaymentExternalService paymentExternalService) 
     : INotifyPaymentHandler
{
     public async Task<bool> HandleAsync(CancellationToken cancellationToken)
     {
          var payments = await paymentExternalService.GetPaymentsAsync(cancellationToken);
          if (!payments.IsSuccess)
          {
               // TODO: ADDED LOGGER
               return false;
          }
          
          foreach (var payment in payments.Content)
          {
               // Todo: Adde logger and handle payment notification logic
          }

          return true;
    }
}
