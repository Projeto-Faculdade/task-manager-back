using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.TasksToDo.GetById;
  public class TaskGetByIdResponse
{
    public string Name { get; set; } = string.Empty!;

    public string Course { get; set; } = string.Empty!;

    public DateTime LimitDate { get; set; }

    public Guid StudentId { get; set; }
}

