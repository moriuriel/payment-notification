using System;
using PaymentNotification.Worker.Application.Adapters.ExternalServices.Notification;
using PaymentNotification.Worker.Application.Handlers.NotifyPayment;

namespace PaymentProcessor.Worker.Application;

public static class ApplicationDependency
{
     public static void AddApplicationDependency(this IServiceCollection services)
          => services.AddScoped<INotifyPaymentHandler, NotifyPaymentHandler>();

     public static void AddFactories(this IServiceCollection services)
          => services.AddScoped<ISendNotificationRequestFactory, SendNotificationRequestFactory>();
}
