using TaskList.Application.Features.TasksManagement.Commands;
using Xunit;

namespace TaskList.Test.Features;

public class DeleteTaskCommandTests
{
    [Fact]
    public void DeleteTaskCommand_Should_Set_Id_Correctly()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var command = new DeleteTaskCommand
        {
            Id = id
        };

        // Assert
        Assert.Equal(id, command.Id);
    }

    [Fact]
    public void DeleteTaskCommand_Should_Allow_Empty_Id()
    {
        // Arrange
        var id = Guid.Empty;

        // Act
        var command = new DeleteTaskCommand
        {
            Id = id
        };

        // Assert
        Assert.Equal(id, command.Id);
    }

    [Fact]
    public void DeleteTaskCommand_Should_Have_Default_Values()
    {
        // Act
        var command = new DeleteTaskCommand();

        // Assert
        Assert.Equal(Guid.Empty, command.Id);
    }
}