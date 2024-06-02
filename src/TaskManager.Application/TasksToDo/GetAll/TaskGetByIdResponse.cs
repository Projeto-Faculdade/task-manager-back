namespace TaskManager.Application.TasksToDo.GetAll;

public class TaskGetByIdResponse
{
    public string Name { get; set; } = string.Empty!;

    public string Course { get; set; } = string.Empty!;

    public DateTime LimitDate { get; set; }

    public Guid StudentId { get; set; }
}