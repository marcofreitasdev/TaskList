using MediatR;
using TaskList.Application.Models;

namespace TaskList.Application.Features.TasksManagement.Queries;

public record GetTaskByIdQuery : IRequest<TaskDto?>
{
    public Guid Id { get; set; }
}