using System.Text.Json.Serialization;

namespace TaskManager.Api.Models;

public class StudentPutRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public string? Name { get; set; } = string.Empty!;

    public string? Email { get; set; } = string.Empty!;

    public string? PreferredLanguage { get; set; } = string.Empty!;
}