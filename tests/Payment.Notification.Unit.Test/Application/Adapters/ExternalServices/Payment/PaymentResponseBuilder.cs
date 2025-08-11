using PaymentNotification.Unit.Test.Shared;
using PaymentNotification.Worker.Application.Adapters.ExternalServices.Payment;

namespace PaymentNotification.Unit.Test.Application.Adapters.ExternalServices.Payment;

public sealed class PaymentResponseBuilder : BaseBuilder<PaymentResponse>
{    public PaymentResponseBuilder()
     {
          _status = Status.Approved;
          _id = Guid.NewGuid();
          _amount = FakerSingleton.GetInstance().Faker.Finance.Amount(min: 1, max: 10000);
          _currency = FakerSingleton.GetInstance().Faker.Finance.Currency().Code;
          _transactionDate = FakerSingleton.GetInstance().Faker.Date.Recent(days: 30);
          _receiver = new AccountHolderBuilder().Build();
          _payer = new AccountHolderBuilder().Build();
     }

     private readonly Status _status;
     private readonly Guid _id;
     private readonly decimal _amount;
     private readonly string _currency;
     private readonly AccountHolder _receiver;
     private readonly AccountHolder _payer;
     private readonly DateTime _transactionDate;

     public override PaymentResponse Build()
     => new()
     {
          Status = _status,
          Id = _id,
          Amount = _amount,
          Currency = _currency,
          TransactionDate = _transactionDate,
          Receiver = _receiver,
          Payer = _payer
     };
}
