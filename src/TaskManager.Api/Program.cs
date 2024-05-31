using TaskManager.Application;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

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

app.Run();