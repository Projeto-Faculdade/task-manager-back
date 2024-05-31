namespace TaskManager.Api.Models;

public class StudentPostRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty!;
}