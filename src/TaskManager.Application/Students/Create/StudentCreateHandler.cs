using MediatR;
using TaskManager.Data;
using TaskManager.Data.Models;
using TaskManager.Notification;

namespace TaskManager.Application.Students.Create;

internal class StudentCreateHandler(TaskManagerContext context, IRabbitMqBroker brokerService) : IRequestHandler<StudentCreateRequest, Guid>
{
    public async Task<Guid> Handle(StudentCreateRequest request, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            Email = request.Email,
            Name = request.Name,
            PreferredLanguage = request.PreferredLanguage,
        };

        _ = await context.Students.AddAsync(student, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var message = new Message
        {
            EmailType = $"wellcome-{student.PreferredLanguage}",
            Recipients = [new() { Email = student.Email, Name = student.Name }]
        };

        brokerService.Publish(message);

        return student.Id;
    }
}