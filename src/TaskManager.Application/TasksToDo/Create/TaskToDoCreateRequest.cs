using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TaskManager.Data.Models;

namespace TaskManager.Application.TasksToDo.Create
{
    public class TaskToDoCreateRequest : IRequest<Guid>
    {
        public string Name_Pt { get; set; } = string.Empty!;

        public string Course { get; set; } = string.Empty!;

        public DateTime LimitDate { get; set; }

        public Guid StudentId { get; set; }
        public string Name_En { get; set; }
    }
}