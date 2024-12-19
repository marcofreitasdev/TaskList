using MediatR;
using TaskList.Application.Models;
using TaskList.Domain.Interfaces;

namespace TaskList.Application.Features.TasksManagement.Queries.Handlers;

public class GetAllTasksQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskDto>>
{
    public async Task<IEnumerable<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await taskRepository.GetAllAsync();
        return tasks.Select(task => new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
        });
    }
}