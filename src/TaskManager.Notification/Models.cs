using System.Text.Json.Serialization;

namespace TaskManager.Notification;

public record Message
{
    [JsonPropertyName("emailType")]
    public string EmailType { get; set; } = string.Empty!;
    [JsonPropertyName("recipients")]
    public List<Recipient> Recipients { get; set; } = []!;
}
public record Recipient
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty!;

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty!;
}