using MediatR;
using TaskList.Application.Models;
using TaskList.Domain.Interfaces;

namespace TaskList.Application.Features.TasksManagement.Queries.Handlers;

public class GetTaskByIdQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetTaskByIdQuery, TaskDto?>
{
    public async Task<TaskDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await taskRepository.GetByIdAsync(request.Id);

        return task == null ? null : new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted
        };
    }
}