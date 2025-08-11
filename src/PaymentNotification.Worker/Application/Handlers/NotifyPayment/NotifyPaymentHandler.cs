using PaymentNotification.Worker.Application.Adapters.ExternalServices;
using PaymentNotification.Worker.Application.Adapters.ExternalServices.Notification;

namespace PaymentNotification.Worker.Application.Handlers.NotifyPayment;

internal sealed class NotifyPaymentHandler(
     IPaymentExternalService paymentExternalService,
     INotificationExternalService notificationExternalService,
     ISendNotificationRequestFactory sendNotificationRequestFactory) 
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
               var request = sendNotificationRequestFactory.Create(payment);
               
               if(!await notificationExternalService.SendNotificationAsync(
                    request,
                    cancellationToken))
               return false;
          }

          return true;
    }
}
