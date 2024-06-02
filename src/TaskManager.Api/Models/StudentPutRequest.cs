using System.Text.Json.Serialization;
using FluentValidation;
using TaskManager.Application.Students.Update;

namespace TaskManager.Api.Models;

public class StudentPutRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public string? Name { get; set; } = string.Empty!;

    public string? Email { get; set; } = string.Empty!;

    public string? PreferredLanguage { get; set; } = string.Empty!;

    public static explicit operator StudentUpdateRequest(StudentPutRequest r)
        => new()
        {
            Id = r.Id,
            Name = r.Name,
            Email = r.Email,
            PreferredLanguage = r.PreferredLanguage,
        };
}

public class StudentPutRequestValidator : AbstractValidator<StudentPutRequest>
{
    public StudentPutRequestValidator()
    {
        RuleFor(cmd => cmd.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);

        RuleFor(cmd => cmd.Email)
            .EmailAddress();

        RuleFor(cmd => cmd.Name)
            .MinimumLength(5)
            .MaximumLength(50);
    }
}