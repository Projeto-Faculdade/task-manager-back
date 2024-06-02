using MediatR;
using TaskManager.Data;
using TaskManager.Data.Models;

namespace TaskManager.Application.TasksToDo.Create;

internal class TaskToDoCreateHandler(TaskManagerContext context) : IRequestHandler<TaskToDoCreateRequest, Guid>
{
    public async Task<Guid> Handle(TaskToDoCreateRequest request, CancellationToken cancellationToken)
    {
        var taskToDo = new TaskToDo
        {
            Course = request.Course,
            Name_En = request.Name_Pt,
            Name_Pt = request.Name_Pt,
            StudentId = request.StudentId,
            LimitDate = request.LimitDate
        };

        _ = await context.Tasks.AddAsync(taskToDo, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return taskToDo.Id;
    }
}