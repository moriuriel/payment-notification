using System;
using PaymentProcessor.Worker.Application.Adapters.ExternalServices.Notification;
using PaymentProcessor.Worker.Application.Handlers.NotifyPayment;

namespace PaymentProcessor.Worker.Application;

public static class ApplicationDependency
{
     public static void AddApplicationDependency(this IServiceCollection services)
          => services.AddScoped<INotifyPaymentHandler, NotifyPaymentHandler>();

     public static void AddFactories(this IServiceCollection services)
          => services.AddScoped<ISendNotificationRequestFactory, SendNotificationRequestFactory>();
}
