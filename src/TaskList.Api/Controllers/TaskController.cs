using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskList.Application.Features.TasksManagement.Commands;
using TaskList.Application.Features.TasksManagement.Queries;

namespace TaskList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Retrieves all tasks.
        /// </summary>
        /// <returns>A list of tasks.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await mediator.Send(new GetAllTasksQuery());
            return Ok(tasks);
        }

        /// <summary>
        /// Retrieves a task by its ID.
        /// </summary>
        /// <param name="id">The ID of the task to retrieve.</param>
        /// <returns>The task with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var task = await mediator.Send(new GetTaskByIdQuery { Id = id });

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="command">The command containing the details of the task to create.</param>
        /// <returns>The ID of the created task.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCommand command)
        {
            var taskId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = taskId }, taskId);
        }

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="id">The ID of the task to update.</param>
        /// <param name="command">The command containing the updated details of the task.</param>
        /// <returns>No content if the update was successful.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateTaskCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes a task by its ID.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>No content if the deletion was successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await mediator.Send(new DeleteTaskCommand { Id = id });
            return NoContent();
        }
    }
}