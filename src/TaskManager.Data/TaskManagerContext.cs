using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Models;

namespace TaskManager.Data;

public class TaskManagerContext(DbContextOptions<TaskManagerContext> options)
    : DbContext(options)
{
    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<TaskToDo> Tasks { get; set; } = default!;
}