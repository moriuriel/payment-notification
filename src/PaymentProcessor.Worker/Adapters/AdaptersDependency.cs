
using PaymentProcessor.Worker.Adapters.ExternalServices;
using PaymentProcessor.Worker.Application.Adapters.ExternalServices;

namespace PaymentProcessor.Worker.Adapters;

public static class AdaptersDependency
{
  public static void AddAdapters(
     this IServiceCollection services,
     IConfiguration configuration)
  {
    services.AddHttpClient<IPaymentExternalService, PaymentExternalService>(client =>
    {
          var baseUrl = configuration.GetValue<string>("PaymentService:BaseUrl");
          ArgumentException.ThrowIfNullOrEmpty(baseUrl);
          client.BaseAddress = new Uri(baseUrl);
          client.Timeout = TimeSpan.FromSeconds(30);
    });
  }
}
