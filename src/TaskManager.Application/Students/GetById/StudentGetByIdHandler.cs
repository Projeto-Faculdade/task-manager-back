using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Application.Students.GetById;

internal class StudentGetByIdHandler(TaskManagerContext context) : IRequestHandler<StudentGetByIdRequest, StudentGetByIdResponse>
{
    public async Task<StudentGetByIdResponse> Handle(StudentGetByIdRequest request, CancellationToken cancellationToken)
    {
        var student = await context.Students.SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

        if (student is null)
        {
            return default!;
        }

        var result = new StudentGetByIdResponse
        {
            Id = student.Id,
            Email = student.Email,
            Name = student.Name,
            PreferredLanguage = student.PreferredLanguage,
        };

        return result;
    }
}