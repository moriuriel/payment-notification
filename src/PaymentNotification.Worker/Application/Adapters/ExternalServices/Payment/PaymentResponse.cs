using System.Text.Json.Serialization;

namespace PaymentNotification.Worker.Application.Adapters.ExternalServices.Payment;

public sealed class PaymentResponse
{
    [JsonPropertyName(name: "status")]
    public Status Status { get; init; }
    [JsonPropertyName(name: "id")]
    public Guid Id { get; init; }
    [JsonPropertyName(name: "amount")]
    public decimal Amount { get; init; }
    [JsonPropertyName(name: "currency")]
    public string Currency { get; init; } = null!;
    [JsonPropertyName(name: "receiver")]
    public AccountHolder Receiver { get; init; } = null!;
    [JsonPropertyName(name: "payer")]
    public AccountHolder Payer { get; init; } = null!;
    [JsonPropertyName(name: "transactionDate")]
    public DateTime TransactionDate { get; init; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    Approved,
    Rejected,
    Pending,
}

