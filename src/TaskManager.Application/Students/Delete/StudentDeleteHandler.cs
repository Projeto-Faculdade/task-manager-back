using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Application.Students.Delete;

internal class StudentDeleteHandler(TaskManagerContext context) : IRequestHandler<StudentDeleteRequest>
{
    public async Task Handle(StudentDeleteRequest request, CancellationToken cancellationToken)
    {
        await context.Students
            .Where(s => s.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
    }
}