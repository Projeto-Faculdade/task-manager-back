using MediatR;
using TaskManager.Data;
using TaskManager.Data.Models;

namespace TaskManager.Application.Students.Create;

internal class StudentCreateHandler(TaskManagerContext context) : IRequestHandler<StudentCreateRequest, Guid>
{
    public async Task<Guid> Handle(StudentCreateRequest request, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            Email = request.Email,
            Name = request.Name,
            PreferredLanguage = request.PreferredLanguage,
        };

        _ = await context.Students.AddAsync(student, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return student.Id;
    }
}