﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Data.Models;

[Table("tasks")]
public class TaskToDo
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name_pt")]
    [MaxLength(100)]
    public string Name_Pt { get; set; } = string.Empty!;

    [Column("name_en")]
    [MaxLength(100)]
    public string Name_En { get; set; } = string.Empty!;

    [Column("course")]
    [MaxLength(100)]
    public string Course { get; set; } = string.Empty!;

    [Column("limit_date")]
    public DateTime LimitDate { get; set; }

    [Column("student_id")]
    public Guid StudentId { get; set; }

    public Student Student { get; set; } = default!;
}