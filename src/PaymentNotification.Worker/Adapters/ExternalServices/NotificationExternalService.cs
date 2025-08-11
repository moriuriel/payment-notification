using System.Text;
using System.Text.Json;
using PaymentNotification.Worker.Application.Adapters.ExternalServices;
using PaymentNotification.Worker.Application.Adapters.ExternalServices.Notification;

namespace PaymentNotification.Worker.Adapters.ExternalServices;

public sealed class NotificationExternalService(
     HttpClient httpClient,
     ILogger<NotificationExternalService> logger) : INotificationExternalService
{
     public async Task<bool> SendNotificationAsync(
          SendNotificationRequest request,
          CancellationToken cancellationToken)
     {
          var content = new StringContent(
               JsonSerializer.Serialize(request),
               Encoding.UTF8,
               "application/json");

          var result = await httpClient.PostAsync(
               "/notifications",
               content,
               cancellationToken);
          if (!result.IsSuccessStatusCode)
          {
               logger.LogWarning(
                    message: "Failed to send notification. StatusCode: {StatusCode}",
                    result.StatusCode);
               return false;
          }
          
          return true;
     }
}
