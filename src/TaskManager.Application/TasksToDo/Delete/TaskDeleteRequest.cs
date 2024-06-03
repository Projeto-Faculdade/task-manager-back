using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TaskManager.Application.TasksToDo.Delete
{
    public class TaskDeleteRequest : IRequest
    {
    public Guid Id { get; set; }
    }
}