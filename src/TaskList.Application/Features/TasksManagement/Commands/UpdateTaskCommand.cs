using MediatR;

namespace TaskList.Application.Features.TasksManagement.Commands;

public record UpdateTaskCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}