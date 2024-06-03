using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FluentValidation;
using TaskManager.Application.TasksToDo.Update;

namespace TaskManager.Api.Models;

public class TaskPutRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }

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

    public static explicit operator TaskUpdateRequest(TaskPutRequest r)
        => new()
        {
            Id = r.Id,
            Course = r.Course,
            LimitDate = r.LimitDate,
            Name_Pt = r.Name_Pt,
            Name_En = r.Name_En,
        };
}

public class TaskPutRequestValidator : AbstractValidator<TaskPutRequest>
{
    public TaskPutRequestValidator()
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