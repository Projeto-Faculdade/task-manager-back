using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Students.Delete;
using TaskManager.Data;

namespace TaskManager.Application.TasksToDo.Delete
{
    public class TaskToDoDeleteHandler
    {
        internal class StudentDeleteHandler(TaskManagerContext context) : IRequestHandler<TaskToDoDeleteRequest>
{
    public async ValueTask Handle(TaskToDoDeleteRequest request, CancellationToken cancellationToken)
    {
        await context.Students
            .Where(s => s.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    System.Threading.Tasks.Task IRequestHandler<TaskToDoDeleteRequest>.Handle(TaskToDoDeleteRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    }
    }
    }
