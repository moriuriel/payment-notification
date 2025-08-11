using PaymentNotification.Worker.Application.Adapters.ExternalServices.Payment;

namespace PaymentNotification.Worker.Application.Adapters.ExternalServices.Notification;

public sealed class SendNotificationRequestFactory : ISendNotificationRequestFactory
{
     public SendNotificationRequest Create(PaymentResponse payment)
          => payment.Status switch
          {
               Status.Approved => SendNotificationRequest.Factory(
                    payment.Id,
                    message: $"Payment approved for {payment.Amount} {payment.Currency} to {payment.Receiver.Name}.",
                    recipient: payment.Payer.TaxId),
               Status.Rejected => SendNotificationRequest.Factory(
                    payment.Id,
                    message: $"Payment rejected for {payment.Amount} {payment.Currency} to {payment.Receiver.Name}.",
                    recipient: payment.Payer.TaxId),
               Status.Pending => SendNotificationRequest.Factory(
                    payment.Id,
                    message: $"Payment Pending for {payment.Amount} {payment.Currency} to {payment.Receiver.Name}.",
                    recipient: payment.Payer.TaxId),
               _ => throw new ArgumentOutOfRangeException(nameof(payment.Status), payment.Status, "Unknown payment status")
          };
}
