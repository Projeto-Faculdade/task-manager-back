using System.ComponentModel.DataAnnotations;
using FluentValidation;
using TaskManager.Application.Students.Create;

namespace TaskManager.Api.Models;

public class StudentPostRequest
{
    [Required]
    public string Name { get; set; } = string.Empty!;

    [Required]
    public string Email { get; set; } = string.Empty!;

    [Required]
    public string PreferredLanguage { get; set; } = string.Empty!;

    public static explicit operator StudentCreateRequest(StudentPostRequest r)
        => new()
        {
            Email = r.Email,
            PreferredLanguage = r.PreferredLanguage,
            Name = r.Name,
        };
}

public class StudentPostRequestValidator : AbstractValidator<StudentPostRequest>
{
    public StudentPostRequestValidator()
    {
        RuleFor(cmd => cmd.Email)
            .EmailAddress();

        RuleFor(cmd => cmd.Name)
            .MinimumLength(5)
            .MaximumLength(50);
    }
}