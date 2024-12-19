using MediatR;
using TaskList.Domain.Interfaces;

namespace TaskList.Application.Features.TasksManagement.Commands.Handlers;

public class DeleteTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<DeleteTaskCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        await taskRepository.DeleteAsync(request.Id);

        return Unit.Value;
    }
}