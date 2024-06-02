using MediatR;

namespace TaskManager.Application.TasksToDo.Create
{
    public class TaskCreateRequest : IRequest<Guid>
    {
        public string Name_Pt { get; set; } = string.Empty!;
        public string Name_En { get; set; } = string.Empty!;

        public string Course { get; set; } = string.Empty!;

        public DateTime LimitDate { get; set; }

        public Guid StudentId { get; set; }
    }
}