using TaskManager.Application.TasksToDo.GetById;

namespace TaskManager.Application.TasksToDo.GetByStudent;

public class TaskGetByStudentResponse : List<TaskGetByIdResponse>
{
    public TaskGetByStudentResponse()
    {
    }

    public TaskGetByStudentResponse(IEnumerable<TaskGetByIdResponse> collection) : base(collection)
    {
    }
}