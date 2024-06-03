using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.TasksToDo.GetById;
using TaskManager.Data;

namespace TaskManager.Application.TasksToDo.GetByStudent;

public class TaskGetByStudentHandler(TaskManagerContext context) : IRequestHandler<TaskGetByStudentRequest, TaskGetByStudentResponse>
{
    public async Task<TaskGetByStudentResponse> Handle(TaskGetByStudentRequest request, CancellationToken cancellationToken)
    {
        var tasks = await context.Tasks
            .Where(t => t.StudentId == request.SudentId)
            .Select(t => new TaskGetByIdResponse
            {
                Course = t.Course,
                LimitDate = t.LimitDate,
                Name = request.PreferredLanguage == "pt" ? t.Name_Pt : t.Name_En,
                StudentId = t.StudentId,
            })
            .ToListAsync(cancellationToken);

        return new TaskGetByStudentResponse(tasks);
    }
}