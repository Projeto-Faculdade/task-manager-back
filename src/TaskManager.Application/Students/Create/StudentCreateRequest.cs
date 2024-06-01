using MediatR;

namespace TaskManager.Application.Students.Create;

public class StudentCreateRequest : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty!;

    public string Email { get; set; } = string.Empty!;

    public string PreferredLanguage { get; set; } = string.Empty!;
}