using TaskList.Application.Features.TasksManagement.Queries;
using Xunit;

namespace TaskList.Test.Features;

public class GetTaskByIdQueryTests
{
    [Fact]
    public void GetTaskByIdQuery_Should_Set_Id_Correctly()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var query = new GetTaskByIdQuery
        {
            Id = id
        };

        // Assert
        Assert.Equal(id, query.Id);
    }

    [Fact]
    public void GetTaskByIdQuery_Should_Allow_Empty_Id()
    {
        // Arrange
        var id = Guid.Empty;

        // Act
        var query = new GetTaskByIdQuery
        {
            Id = id
        };

        // Assert
        Assert.Equal(id, query.Id);
    }

    [Fact]
    public void GetTaskByIdQuery_Should_Have_Default_Values()
    {
        // Act
        var query = new GetTaskByIdQuery();

        // Assert
        Assert.Equal(Guid.Empty, query.Id);
    }
}