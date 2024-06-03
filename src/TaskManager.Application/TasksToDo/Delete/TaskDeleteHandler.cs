using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Application.TasksToDo.Delete
{
    public class TaskDeleteHandler
    {
        internal class StudentDeleteHandler(TaskManagerContext context) : IRequestHandler<TaskDeleteRequest>
        {
            public async Task Handle(TaskDeleteRequest request, CancellationToken cancellationToken)
            {
                await context.Tasks
                           .Where(t => t.Id == request.Id)
                           .ExecuteDeleteAsync(cancellationToken);
            }
        }
    }
}