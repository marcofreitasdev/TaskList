using MediatR;
using TaskList.Application.Features.TasksManagement.Commands;
using TaskList.Domain.Entities;
using TaskList.Domain.Interfaces;

namespace TaskList.Application.Features.TasksManagement.Commands.Handlers;

public class CreateTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<CreateTaskCommand, Guid>
{
    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskItem = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        await taskRepository.AddAsync(taskItem);

        return taskItem.Id;
    }
}