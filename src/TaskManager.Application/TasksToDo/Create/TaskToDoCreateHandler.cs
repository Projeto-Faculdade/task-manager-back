using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Data.Models;
using TaskManager.Notification;

namespace TaskManager.Application.TasksToDo.Create;

internal class TaskToDoCreateHandler(TaskManagerContext context, IRabbitMqBroker brokerService) : IRequestHandler<TaskCreateRequest, Guid>
{
    public async Task<Guid> Handle(TaskCreateRequest request, CancellationToken cancellationToken)
    {
        var task = new TaskToDo
        {
            Course = request.Course,
            Name_En = request.Name_En,
            Name_Pt = request.Name_Pt,
            StudentId = request.StudentId,
            LimitDate = request.LimitDate
        };

        _ = await context.Tasks.AddAsync(task, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var student = await context.Students.FirstAsync(s => s.Id == request.StudentId, cancellationToken);

        var message = new Message
        {
            EmailType = $"newtask-{student.PreferredLanguage}",
            Recipients = [new() { Email = student.Email, Name = student.Name }]
        };

        brokerService.Publish(message);
        return task.Id;
    }
}