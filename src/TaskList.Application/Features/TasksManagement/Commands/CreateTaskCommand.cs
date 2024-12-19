using MediatR;

namespace TaskList.Application.Features.TasksManagement.Commands;

public record CreateTaskCommand : IRequest<Guid>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
}