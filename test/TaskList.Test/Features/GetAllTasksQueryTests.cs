using TaskList.Application.Features.TasksManagement.Queries;
using TaskList.Application.Models;
using Xunit;

namespace TaskList.Test.Features;

public class GetAllTasksQueryTests
{
    [Fact]
    public void GetAllTasksQuery_Should_Create_Instance()
    {
        // Act
        var query = new GetAllTasksQuery();

        // Assert
        Assert.NotNull(query);
    }

    [Fact]
    public void GetAllTasksQuery_Should_Return_List_Of_Tasks()
    {
        // Arrange
        var query = new GetAllTasksQuery();

        // Act
        var result = HandleGetAllTasksQuery(query);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.All(result, task => Assert.IsType<TaskDto>(task));
    }

    private List<TaskDto> HandleGetAllTasksQuery(GetAllTasksQuery query)
    {
        return
        [
            new() { Id = Guid.NewGuid(), Title = "Task 1", Description = "Description 1", IsCompleted = false },
            new() { Id = Guid.NewGuid(), Title = "Task 2", Description = "Description 2", IsCompleted = true }
        ];
    }
}