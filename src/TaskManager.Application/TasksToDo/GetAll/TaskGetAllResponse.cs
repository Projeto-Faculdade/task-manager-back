using TaskManager.Application.TasksToDo.GetById;

namespace TaskManager.Application.TasksToDo.GetAll;
public class TaskGetAllResponse : List<TaskGetByIdResponse>
{

    public TaskGetAllResponse()
    {
    }

    public TaskGetAllResponse(IEnumerable<TaskGetByIdResponse> collection) : base(collection)
    {
    }

}




