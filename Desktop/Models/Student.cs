using System.Text.Json.Serialization;

namespace Desktop.Models;

public class Student
{
    [JsonPropertyName("_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = "";

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = "";

    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; } = "";

    [JsonPropertyName("personalNumber")]
    public string PersonalNumber { get; set; } = "";

    [JsonPropertyName("address")]
    public string Address { get; set; } = "";

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; } = "";

    [JsonPropertyName("city")]
    public string City { get; set; } = "";
}