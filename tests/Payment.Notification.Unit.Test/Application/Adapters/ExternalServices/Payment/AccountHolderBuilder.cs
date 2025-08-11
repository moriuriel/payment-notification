using Bogus.Extensions.Brazil;
using PaymentNotification.Unit.Test.Shared;
using PaymentNotification.Worker.Application.Adapters.ExternalServices.Payment;

namespace PaymentNotification.Unit.Test.Application.Adapters.ExternalServices.Payment;

public sealed class AccountHolderBuilder : BaseBuilder<AccountHolder>
{
     public AccountHolderBuilder()
     {
          _name = FakerSingleton.GetInstance().Faker.Person.FullName;
          _taxId = FakerSingleton.GetInstance().Faker.Person.Cpf();
          _accountNumber = FakerSingleton.GetInstance().Faker.Finance.Account();
          _bank = FakerSingleton.GetInstance().Faker.Random.Word();
     }
     private readonly string _name;
     private readonly string _taxId;
     private readonly string _accountNumber;
     private readonly string _bank;

     public override AccountHolder Build()
     => new()
     {
          Name = _name,
          TaxId = _taxId,
          AccountNumber = _accountNumber,
          Bank = _bank
     };
}
