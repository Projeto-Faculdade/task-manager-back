using MediatR;
using TaskManager.Application.TasksToDo.GetAll;

namespace TaskManager.Application;

public class TaskGetAllRequest : IRequest<TaskGetAllResponse>
{
    public string PreferredLanguage { get; set; } = string.Empty;
}


