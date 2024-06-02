using MediatR;

namespace TaskManager.Application.Students.GetByEmail;

public class StudentByEmailRequest : IRequest<StudentByEmailResponse>
{
    public string Email { get; set; } = string.Empty!;
}