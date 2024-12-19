using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities;
using TaskList.Domain.Interfaces;
using TaskList.Infrastructure.Context;

namespace TaskList.Infrastructure.Repositories;

public class TaskRepository(ApplicationDbContext context) : ITaskRepository
{
    public async Task<TaskItem?> GetByIdAsync(Guid id) => await context.Tasks!.FindAsync(id);

    public async Task<IEnumerable<TaskItem>> GetAllAsync() => await context.Tasks!.ToListAsync();

    public async Task AddAsync(TaskItem task)
    {
        context.Tasks!.Add(task);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskItem task)
    {
        context.Tasks!.Update(task);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var task = await context.Tasks!.FindAsync(id);
        if (task == null) return;

        context.Tasks.Remove(task);
        await context.SaveChangesAsync();
    }
}
