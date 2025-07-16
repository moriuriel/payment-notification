using PaymentProcessor.Worker.Application.Handlers.NotifyPayment;

namespace PaymentProcessor.Worker;

public class Worker(
     ILogger<Worker> logger,
     IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var notifyPaymentHandler = scope.ServiceProvider.GetRequiredService<INotifyPaymentHandler>();

        var result = await notifyPaymentHandler.HandleAsync(stoppingToken);

        if (result)
        {
            logger.LogInformation("Payment notification handled successfully.");
        }
        else
        {
            logger.LogError("Failed to handle payment notification.");
        }
    }
}
