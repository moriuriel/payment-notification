namespace PaymentNotification.Worker.Application.Adapters.ExternalServices.Notification;

public class SendNotificationRequest
{     
     private SendNotificationRequest(
          Guid id,
          string message,
          string recipient)
     {
          Id = id;
          Message = message;
          Recipient = recipient;
     }

     public Guid Id { get; private set; }
     public string Message { get; private set; }
     public string Recipient { get; private set; }

     public static SendNotificationRequest Factory(
          Guid id,
          string message,
          string recipient)
          => new(id, message, recipient);
}
