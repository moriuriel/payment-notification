using PaymentProcessor.Worker.Application.Adapters.ExternalServices.Notification;

namespace PaymentProcessor.Worker.Application.Adapters.ExternalServices;

public interface INotificationExternalService
{
     Task<bool> SendNotificationAsync(
          SendNotificationRequest request,
          CancellationToken cancellationToken);
}
