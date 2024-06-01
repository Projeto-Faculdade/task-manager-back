using MediatR;

namespace TaskManager.Application.Students.GetById;

public class StudentGetByIdRequest : IRequest<StudentGetByIdResponse>
{
    public Guid Id { get; set; }
    public string PreferredLanguage { get; set; } = string.Empty!;
}
