namespace TaskManager.Application.TasksToDo.GetById;

public class TaskGetByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty!;

    public string Course { get; set; } = string.Empty!;

    public DateTime LimitDate { get; set; }

    public Guid StudentId { get; set; }
}