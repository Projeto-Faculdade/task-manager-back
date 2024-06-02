namespace TaskManager.Application.Students.GetByEmail;

public class StudentByEmailResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty!;

    public string Email { get; set; } = string.Empty!;

    public string PreferredLanguage { get; set; } = string.Empty!;
}