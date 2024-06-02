using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Application.Students.GetByEmail;

public class StudentByEmailHandler(TaskManagerContext context) : IRequestHandler<StudentByEmailRequest, StudentByEmailResponse>
{
    public async Task<StudentByEmailResponse> Handle(StudentByEmailRequest request, CancellationToken cancellationToken)
    {
        var student = await context.Students
            .SingleOrDefaultAsync(s => s.Email == request.Email, cancellationToken);

        if (student == default)
        {
            return default!;
        }

        return new StudentByEmailResponse
        {
            Email = student.Email,
            Name = student.Name,
            PreferredLanguage = student.PreferredLanguage,
        };
    }
}