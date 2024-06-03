using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.TasksToDo.GetById;
using TaskManager.Data;

namespace TaskManager.Application;

internal class TaskGetByIdHandler(TaskManagerContext context) : IRequestHandler<TaskGetByIdRequest, TaskGetByIdResponse>
{
    public async Task<TaskGetByIdResponse> Handle(TaskGetByIdRequest request, CancellationToken cancellationToken)
    {
        var task = await context.Tasks.SingleOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
        if (task is null)
        {
            return default!;
        }

        var result = new TaskGetByIdResponse
        {
            LimitDate = task.LimitDate,
            Course = task.Course,
            Name = request.PreferredLanguage == "pt" ? task.Name_Pt : task.Name_En,
        };

        return result;
    }
}
