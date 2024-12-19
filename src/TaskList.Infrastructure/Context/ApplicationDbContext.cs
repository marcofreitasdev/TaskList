using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities;

namespace TaskList.Infrastructure.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem>? Tasks { get; set; }
}
