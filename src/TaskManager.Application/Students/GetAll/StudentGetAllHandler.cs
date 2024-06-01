using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Students.GetById;
using TaskManager.Data;

namespace TaskManager.Application.Students.GetAll;

internal class StudentGetAllHandler(TaskManagerContext context) : IRequestHandler<StudentGetAllRequest, StudentGetAllResponse>
{
    public async Task<StudentGetAllResponse> Handle(StudentGetAllRequest request, CancellationToken cancellationToken)
    {
        var list = await context.Students
            .Select(s => new StudentGetByIdResponse
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                PreferredLanguage = s.PreferredLanguage
            }).ToListAsync(cancellationToken);

        return new StudentGetAllResponse(list);
    }
}