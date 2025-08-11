using PaymentNotification.Worker.Application.Adapters.ExternalServices.Notification;

namespace PaymentNotification.Worker.Application.Adapters.ExternalServices;

public interface INotificationExternalService
{
     Task<bool> SendNotificationAsync(
          SendNotificationRequest request,
          CancellationToken cancellationToken);
}
