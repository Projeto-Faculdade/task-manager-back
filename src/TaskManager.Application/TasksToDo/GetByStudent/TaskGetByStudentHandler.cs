using MediatR;
using TaskManager.Data;

namespace TaskManager.Application.TasksToDo.GetByStudent;

public class TaskGetByStudentHandler(TaskManagerContext context) : IRequestHandler<TaskGetByStudentRequest, TaskGetByStudentResponse>
{
    public async Task<TaskGetByStudentResponse> Handle(TaskGetByStudentRequest request, CancellationToken cancellationToken)
    {


        await Task.CompletedTask;
        return new();
    }
}