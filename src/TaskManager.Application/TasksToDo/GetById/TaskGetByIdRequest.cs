using MediatR;
using TaskManager.Application.TasksToDo.GetById;

namespace TaskManager.Application;

public class TaskGetByIdRequest :IRequest<TaskGetByIdResponse>
{   
     public Guid Id { get; set; }
    public string PreferredLanguage { get; set; } = string.Empty!;
}
