using Microsoft.EntityFrameworkCore;
using TaskManager.Application;
using TaskManager.Data;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

var connectionString = configuration.GetConnectionString("TaskManagerContext")
    ?? throw new InvalidOperationException("Connection string 'TaskManagerContext' not found.");

services.AddDbContext<TaskManagerContext>(options =>
    options.UseSqlite(connectionString));

services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(IApplicationReference).Assembly));
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TaskManagerContext>();
    await context.Database.MigrateAsync();
}
await app.RunAsync();