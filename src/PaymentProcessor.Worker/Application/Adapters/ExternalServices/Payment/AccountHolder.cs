using System.Text.Json.Serialization;

namespace PaymentProcessor.Worker.Application.Adapters.ExternalServices.Payment;

public sealed class AccountHolder
{
     [JsonPropertyName(name: "name")]
     public string Name { get; init; } = null!;
     [JsonPropertyName(name: "taxId")]
     public string TaxId { get; init; } = null!;
     [JsonPropertyName(name: "accountNumber")]
     public string AccountNumber { get; init; } = null!;
     [JsonPropertyName(name: "bank")]
     public string Bank { get; init; } = null!;
}
