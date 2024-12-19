using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskList.Application.Features.TasksManagement.Commands.Handlers;
using TaskList.Domain.Interfaces;
using TaskList.Infrastructure.Context;
using TaskList.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "TaskList API",
        Version = "v1",
        Description = "API para gerenciar tarefas.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Marco Freitas"
        }
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateTaskCommandHandler).GetTypeInfo().Assembly);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskList API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();