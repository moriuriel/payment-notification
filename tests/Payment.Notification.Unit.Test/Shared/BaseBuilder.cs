namespace PaymentProcessor.Unit.Test.Shared;

public abstract class BaseBuilder<T> where T : class
{
     public abstract T Build();
}
