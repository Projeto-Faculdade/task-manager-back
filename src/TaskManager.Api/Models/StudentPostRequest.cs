using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Models;

public class StudentPostRequest
{
    [Required]
    public string Name { get; set; } = string.Empty!;

    [Required]
    public string Email { get; set; } = string.Empty!;

    [Required]
    public string PreferredLanguage { get; set; } = string.Empty!;
}