using MediatR;

namespace TaskManager.Application.TasksToDo.Update;

public class TaskUpdateRequest : IRequest
{
    public Guid Id { get; set; }
    public string Name_Pt { get; set; } = string.Empty!;

    public string Name_En { get; set; } = string.Empty!;

    public string Course { get; set; } = string.Empty!;

    public DateTime LimitDate { get; set; }

}