using Microsoft.EntityFrameworkCore;
using TaskManager.Application;
using TaskManager.Data;
using TaskManager.Notification;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

var connectionString = configuration.GetConnectionString("TaskManagerContext")
    ?? throw new InvalidOperationException("Connection string 'TaskManagerContext' not found.");

services.AddDbContext<TaskManagerContext>(options =>
    options.UseSqlite(connectionString));

if (configuration.GetSection("RabbitMq:Enable").Get<bool>())
{
    services.AddSingleton<IRabbitMqBroker, RabbitMqBrokerService>();
}
else
{
    services.AddSingleton<IRabbitMqBroker, RabbitMqBrokerMockService>();
}

services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(IApplicationReference).Assembly));
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(builder => builder
    .SetIsOriginAllowed(orign => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TaskManagerContext>();
    await context.Database.MigrateAsync();
}
await app.RunAsync();