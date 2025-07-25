using System.Text.Json;
using Microsoft.Extensions.Logging;
using PaymentProcessor.Worker.Application.Adapters.ExternalServices;
using PaymentProcessor.Worker.Application.Adapters.ExternalServices.Payment;
using PaymentProcessor.Worker.Application.Shared;

namespace PaymentProcessor.Worker.Adapters.ExternalServices;

public class PaymentExternalService(
     HttpClient httpClient,
     ILogger<PaymentExternalService> logger) : IPaymentExternalService
{
     public async Task<ResultT<IEnumerable<PaymentResponse>>> GetPaymentsAsync(
          CancellationToken cancellationToken)
     {
          var result = await httpClient.GetAsync("/payments", cancellationToken);
          if (!result.IsSuccessStatusCode)
          {
               var resultType = result.StatusCode switch
               {
                    System.Net.HttpStatusCode.BadRequest
                         => ResultT<IEnumerable<PaymentResponse>>.Type.ValidationFailure,
                    _ => ResultT<IEnumerable<PaymentResponse>>.Type.DependencyFailure
               };

               logger.LogWarning("Failed to fetch payments. StatusCode: {StatusCode}", result.StatusCode);
               return ResultT<IEnumerable<PaymentResponse>>.Failure(resultType);
          }
          try
          {
               var content = await result.Content.ReadAsStringAsync(cancellationToken);
               var payments = JsonSerializer.Deserialize<IEnumerable<PaymentResponse>>(content);
               logger.LogInformation("Successfully fetched payments. Count: {Count}", payments?.Count() ?? 0);
               return ResultT<IEnumerable<PaymentResponse>>.Success(payments!);
          }
          catch (Exception ex)
          {
               logger.LogError(ex, "Error deserializing payments response.");
               return ResultT<IEnumerable<PaymentResponse>>.Failure(
                    ResultT<IEnumerable<PaymentResponse>>.Type.DeserializeFailure);
          }
     }
}
