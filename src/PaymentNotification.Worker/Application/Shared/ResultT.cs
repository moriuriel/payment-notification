namespace PaymentProcessor.Worker.Application.Shared;

public sealed class ResultT<T>
{
     private ResultT(bool isSuccess, T content, Type resultType)
     {
          IsSuccess = isSuccess;
          Content = content;
          ResultType = resultType;
     }

     public bool IsSuccess { get; }
     public T Content { get; }
     public Type ResultType { get; }
     public static ResultT<T> Success(T content) => new(true, content, Type.Success);
     public static ResultT<T> Failure(Type resultType) => new(false, default!,resultType);

     public enum Type
     {
          Success,
          DependencyFailure,
          ValidationFailure,
          DeserializeFailure
     }
}
