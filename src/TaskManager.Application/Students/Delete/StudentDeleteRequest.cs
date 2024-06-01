using MediatR;

namespace TaskManager.Application.Students.Delete;

public class StudentDeleteRequest : IRequest
{
    public Guid Id { get; set; }
}