namespace PaymentProcessor.Worker.Application.Handlers.NotifyPayment;

public interface INotifyPaymentHandler
{
     Task<bool> HandleAsync(CancellationToken cancellationToken);
}
