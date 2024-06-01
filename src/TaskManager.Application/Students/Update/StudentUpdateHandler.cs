using MediatR;

namespace TaskManager.Application.Students.Update;

internal class StudentUpdateHandler : IRequestHandler<StudentUpdateRequest>
{
    public Task Handle(StudentUpdateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}