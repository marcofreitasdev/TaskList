using MediatR;

namespace TaskList.Application.Features.TasksManagement.Commands;

public record DeleteTaskCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}