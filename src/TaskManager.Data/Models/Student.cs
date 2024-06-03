using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Data.Models;

[Table("students")]
[Index(nameof(Name), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class Student
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; } = string.Empty!;

    [Required]
    [MaxLength(150)]
    [Column("email")]
    public string Email { get; set; } = string.Empty!;

    [Required]
    [MaxLength(5)]
    [Column("preferred_language")]
    public string PreferredLanguage { get; set; } = string.Empty!;
}