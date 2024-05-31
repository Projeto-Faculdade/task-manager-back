using MediatR;

namespace TaskManager.Application.Students.Create;

internal class StudentCreateHandler : IRequestHandler<StudentCreateRequest, Guid>
{
    public async Task<Guid> Handle(StudentCreateRequest request, CancellationToken cancellationToken)
    {
        return Guid.NewGuid();
    }
}