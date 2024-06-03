using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Application.TasksToDo.Update;

internal class TaskUpdateHandler(TaskManagerContext context) : IRequestHandler<TaskUpdateRequest>
{
    public async Task Handle(TaskUpdateRequest request, CancellationToken cancellationToken)
    {
        await context.Tasks
            .Where(t => t.Id == request.Id)
            .ExecuteUpdateAsync(p =>
                p.SetProperty(p => p.Name_En, request.Name_En)
                .SetProperty(p => p.Name_Pt, request.Name_Pt)
                .SetProperty(p => p.Course, request.Course)
                .SetProperty(p => p.LimitDate, request.LimitDate)
            , cancellationToken);
    }
}