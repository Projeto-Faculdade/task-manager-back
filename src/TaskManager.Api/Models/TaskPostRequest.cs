using System.ComponentModel.DataAnnotations;
using FluentValidation;
using TaskManager.Api.Models;
using TaskManager.Application.TasksToDo.Create;

namespace TaskManager.Api.Models
{
    public class TaskPostRequest
    {
        [Required]
        public string Name_Pt { get; set; } = string.Empty!;

        [Required]
        public string Name_En { get; set; } = string.Empty!;

        [Required]
        public string Course { get; set; } = string.Empty!;

        [Required]
        public DateTime LimitDate { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        public static explicit operator TaskCreateRequest(TaskPostRequest r)
            => new()
            {
                StudentId = r.StudentId,
                Name_Pt = r.Name_Pt,
                Name_En = r.Name_En,
                Course = r.Course,
                LimitDate = r.LimitDate
            };
    }
}

public class TaskPostRequestValidator : AbstractValidator<TaskPostRequest>
{
    public TaskPostRequestValidator()
    {
        RuleFor(cmd => cmd.Course)
             .MinimumLength(5)
            .MaximumLength(50);

        RuleFor(cmd => cmd.Name_Pt)
            .MinimumLength(5)
            .MaximumLength(50);

        RuleFor(cmd => cmd.Name_En)
            .MinimumLength(5)
            .MaximumLength(100);

        RuleFor(cmd => cmd.LimitDate)
            .GreaterThanOrEqualTo(DateTime.Now);
    }
}