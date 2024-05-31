using MediatR;

namespace TaskManager.Application.Students.Update;

public class StudentUpdateHandler : IRequestHandler<StudentUpdateRequest>
{
    public Task Handle(StudentUpdateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}