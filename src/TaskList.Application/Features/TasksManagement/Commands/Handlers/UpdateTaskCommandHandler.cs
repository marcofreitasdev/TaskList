using MediatR;
using TaskList.Application.Features.TasksManagement.Commands;
using TaskList.Domain.Entities;
using TaskList.Domain.Interfaces;

namespace TaskList.Application.Features.TasksManagement.Commands.Handlers;

public class UpdateTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<UpdateTaskCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskItem
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            IsCompleted = request.IsCompleted,
            CompletedAt = request.IsCompleted ? DateTime.UtcNow : null
        };

        await taskRepository.UpdateAsync(task);

        return Unit.Value;
    }
}