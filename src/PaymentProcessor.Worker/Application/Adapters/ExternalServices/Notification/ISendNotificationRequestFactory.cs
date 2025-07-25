using PaymentProcessor.Worker.Application.Adapters.ExternalServices.Payment;

namespace PaymentProcessor.Worker.Application.Adapters.ExternalServices.Notification;

public interface ISendNotificationRequestFactory
{
     /// <summary>
     /// Creates a request to send a notification.
     /// </summary>
     /// <param name="Payment">The payment of notification to send.</param>
     /// <returns>A request object for sending the notification.</returns>
     SendNotificationRequest Create(PaymentResponse payment);
}
