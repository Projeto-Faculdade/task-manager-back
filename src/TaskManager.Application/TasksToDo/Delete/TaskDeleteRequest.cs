using MediatR;

namespace TaskManager.Application.TasksToDo.Delete
{
    public class TaskDeleteRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}