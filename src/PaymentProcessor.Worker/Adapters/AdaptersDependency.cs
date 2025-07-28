
using PaymentProcessor.Worker.Adapters.ExternalServices;
using PaymentProcessor.Worker.Application.Adapters.ExternalServices;

namespace PaymentProcessor.Worker.Adapters;

public static class AdaptersDependency
{
  public static void AddAdapters(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    var baseUrl = configuration.GetValue<string>(key: "ExternalService:BaseUrl");
    ArgumentException.ThrowIfNullOrEmpty(baseUrl);

    services.AddHttpClient<IPaymentExternalService, PaymentExternalService>(client =>
    {
      client.BaseAddress = new Uri(baseUrl);
      client.Timeout = TimeSpan.FromSeconds(30);
    });

    services.AddHttpClient<INotificationExternalService, NotificationExternalService>(client =>
    {
      client.BaseAddress = new Uri(baseUrl);
      client.Timeout = TimeSpan.FromSeconds(30);
    });
  }
}
