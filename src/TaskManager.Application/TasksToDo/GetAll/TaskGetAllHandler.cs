using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.TasksToDo.GetAll;
using TaskManager.Application.TasksToDo.GetById;
using TaskManager.Data;

namespace TaskManager.Application;

internal class TaskGetAllHandler(TaskManagerContext context) : IRequestHandler<TaskGetAllRequest,TaskGetAllResponse>
{
    public async Task<TaskGetAllResponse> Handle(TaskGetAllRequest request, CancellationToken cancellationToken)
    {
        var list = await context.Tasks
        .Select(b => new TaskGetByIdResponse
        {
            Course = b.Course,
            LimitDate = b.LimitDate,
            Name = request.PreferredLanguage == "pt" ? b.Name_Pt : b.Name_En,
            

        }).ToListAsync(cancellationToken);
        return new TaskGetAllResponse(list);
    }
}
