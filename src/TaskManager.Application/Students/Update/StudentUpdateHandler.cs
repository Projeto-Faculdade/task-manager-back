using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Application.Students.Update;

internal class StudentUpdateHandler(TaskManagerContext context) : IRequestHandler<StudentUpdateRequest>
{
    public async Task Handle(StudentUpdateRequest request, CancellationToken cancellationToken)
    {
        await context.Students.Where(s => s.Id == request.Id)
             .ExecuteUpdateAsync(p =>
                p.SetProperty(s => s.PreferredLanguage, request.PreferredLanguage)
                .SetProperty(s => s.Name, request.Name)
                .SetProperty(s => s.Email, request.Email)
            , cancellationToken);
    }
}