using MediatR;
using TaskList.Application.Models;

namespace TaskList.Application.Features.TasksManagement.Queries;

public record GetAllTasksQuery : IRequest<IEnumerable<TaskDto>>;