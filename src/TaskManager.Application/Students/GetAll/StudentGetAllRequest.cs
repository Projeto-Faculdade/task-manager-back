using MediatR;

namespace TaskManager.Application.Students.GetAll;

public class StudentGetAllRequest : IRequest<StudentGetAllResponse>
{
    public string PreferredLanguage { get; set; } = string.Empty!;
}