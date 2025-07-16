using System.Text.Json;
using PaymentProcessor.Worker.Application.Adapters.ExternalServices;
using PaymentProcessor.Worker.Application.Adapters.ExternalServices.Payment;
using PaymentProcessor.Worker.Application.Shared;

namespace PaymentProcessor.Worker.Adapters.ExternalServices;

public class PaymentExternalService(HttpClient httpClient) : IPaymentExternalService
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

               return ResultT<IEnumerable<PaymentResponse>>.Failure(resultType);
          }
          try
          {
               var content = await result.Content.ReadAsStringAsync(cancellationToken);
               var payments = JsonSerializer.Deserialize<IEnumerable<PaymentResponse>>(content);
               return ResultT<IEnumerable<PaymentResponse>>.Success(payments!);
          }
          catch
          {
               return ResultT<IEnumerable<PaymentResponse>>.Failure(
                    ResultT<IEnumerable<PaymentResponse>>.Type.DeserializeFailure);
          }
     }
}
