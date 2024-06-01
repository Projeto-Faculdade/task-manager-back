using System.Text.Json.Serialization;
using TaskManager.Application.Students.Update;

namespace TaskManager.Api.Models;

public class StudentPutRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public string? Name { get; set; } = string.Empty!;

    public string? Email { get; set; } = string.Empty!;

    public string? PreferredLanguage { get; set; } = string.Empty!;

    public static implicit operator StudentUpdateRequest(StudentPutRequest r)
    {
        return new StudentUpdateRequest();
    }
}