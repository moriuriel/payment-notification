namespace PaymentNotification.Unit.Test.Application.Handlers.NotifyPayment;

using PaymentNotification.Worker.Application.Handlers.NotifyPayment;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using PaymentNotification.Worker.Application.Adapters.ExternalServices;
using PaymentNotification.Worker.Application.Adapters.ExternalServices.Notification;
using PaymentNotification.Worker.Application.Adapters.ExternalServices.Payment;
using PaymentProcessor.Worker.Application.Shared;

public sealed class NotifiyPaymentHandlerTest
{
     public NotifiyPaymentHandlerTest()
          => _handler = new NotifyPaymentHandler(
               _paymentExternalServiceMock.Object,
               _notificationExternalServiceMock.Object,
               _sendNotificationRequestFactoryMock.Object,
               _loggerMock.Object);
     private readonly NotifyPaymentHandler _handler;
     private readonly Mock<IPaymentExternalService> _paymentExternalServiceMock = new();
     private readonly Mock<INotificationExternalService> _notificationExternalServiceMock = new();
     private readonly Mock<ISendNotificationRequestFactory> _sendNotificationRequestFactoryMock = new();
     private readonly Mock<ILogger<NotifyPaymentHandler>> _loggerMock = new();
     private readonly CancellationToken _cancellationToken = CancellationToken.None;
     [Fact]
     public async Task HandleAsync_ShouldReturnFalse_WhenGetPaymentsFails()
     {
          // Arrange
          var paymentsResult = ResultT<IEnumerable<PaymentResponse>>.Failure(
               ResultT<IEnumerable<PaymentResponse>>.Type.DependencyFailure);

          _paymentExternalServiceMock
               .Setup(x => x.GetPaymentsAsync(_cancellationToken))
               .ReturnsAsync(paymentsResult);

          // Act
          var result = await _handler.HandleAsync(_cancellationToken);

          // Assert
          result.Should().BeFalse();

          _paymentExternalServiceMock.Verify(
               x => x.GetPaymentsAsync(_cancellationToken), Times.Once);

          _notificationExternalServiceMock.Verify(
               x => x.SendNotificationAsync(
                    It.IsAny<SendNotificationRequest>(),
                    _cancellationToken),
               Times.Never);

          _sendNotificationRequestFactoryMock.Verify(
               x => x.Create(It.IsAny<PaymentResponse>()),
               Times.Never);            
     }
}
