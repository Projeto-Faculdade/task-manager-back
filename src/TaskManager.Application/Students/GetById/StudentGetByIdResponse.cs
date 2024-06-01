namespace TaskManager.Application.Students.GetById;

public class StudentGetByIdResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty!;

    public string Email { get; set; } = string.Empty!;

    public string PreferredLanguage { get; set; } = string.Empty!;
}