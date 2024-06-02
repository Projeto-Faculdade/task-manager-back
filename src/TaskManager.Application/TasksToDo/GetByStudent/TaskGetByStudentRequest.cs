using MediatR;

namespace TaskManager.Application.TasksToDo.GetByStudent;

public class TaskGetByStudentRequest : IRequest<TaskGetByStudentResponse>
{
    public Guid SudentId { get; set; }
    public string PreferredLanguage { get; set; }
}
