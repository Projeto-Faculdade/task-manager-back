using System.ComponentModel.DataAnnotations;
using FluentValidation;
using TaskManager.Api.Models;
using TaskManager.Application.TasksToDo.Create;

namespace TaskManager.Api.Models
{
    public class TaskItemPostRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty!;

        [Required]
        public string Course { get; set; } = string.Empty!;

        [Required]
        public DateTime LimitDate { get; set; }

        [Required]
        public Guid StudentId { get; set; }
      
        public static explicit operator TaskToDoCreateRequest(TaskItemPostRequest r)
            => new()
            {
                StudentId = r.StudentId,
                Name = r.Name,
                Course = r.Course,
                LimitDate = r.LimitDate
            };  
    }   
}
public class TaskPutRequestValidator : AbstractValidator<TaskItemPostRequest>
{
    public TaskPutRequestValidator()
    {
        RuleFor(cmd => cmd.Course)
            .NotEmpty();


        RuleFor(cmd => cmd.Name)
            .MinimumLength(5)
            .MaximumLength(50);
    }
}