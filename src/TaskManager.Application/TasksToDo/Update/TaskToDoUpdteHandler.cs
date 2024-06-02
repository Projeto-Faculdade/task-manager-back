using MediatR;
using TaskManager.Data;

namespace TaskManager.Application.TasksToDo.Update;
internal class TaskToDoUpdateHandler(TaskManagerContext context) : IRequestHandler<TaskUpdateRequest>
{
    public Task Handle(TaskUpdateRequest request, CancellationToken cancellationToken)
    {
       
        return Task.CompletedTask;
    }  
}
