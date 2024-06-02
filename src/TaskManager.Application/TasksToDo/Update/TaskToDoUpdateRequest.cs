using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TaskManager.Application.TasksToDo.Update
{
    public class TaskUpdateRequest : IRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty!;

        public string? Course { get; set; } = string.Empty!;

        public DateTime LimitDate { get; set; }

        public Guid StudentId { get; set; }
       
    }
}