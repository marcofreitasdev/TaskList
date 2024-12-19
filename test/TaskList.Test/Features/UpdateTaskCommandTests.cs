using TaskList.Application.Features.TasksManagement.Commands;

namespace TaskList.Test.Features;

public class UpdateTaskCommandTests
{
    [Fact]
    public void UpdateTaskCommand_Should_Set_Properties_Correctly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var title = "Test Title";
        var description = "Test Description";
        var isCompleted = true;

        // Act
        var command = new UpdateTaskCommand
        {
            Id = id,
            Title = title,
            Description = description,
            IsCompleted = isCompleted
        };

        // Assert
        Assert.Equal(id, command.Id);
        Assert.Equal(title, command.Title);
        Assert.Equal(description, command.Description);
        Assert.Equal(isCompleted, command.IsCompleted);
    }

    [Fact]
    public void UpdateTaskCommand_Should_Allow_Null_Title_And_Description()
    {
        // Arrange
        var id = Guid.NewGuid();
        string? title = null;
        string? description = null;
        var isCompleted = false;

        // Act
        var command = new UpdateTaskCommand
        {
            Id = id,
            Title = title,
            Description = description,
            IsCompleted = isCompleted
        };

        // Assert
        Assert.Equal(id, command.Id);
        Assert.Null(command.Title);
        Assert.Null(command.Description);
        Assert.False(command.IsCompleted);
    }

    [Fact]
    public void UpdateTaskCommand_Should_Have_Default_Values()
    {
        // Act
        var command = new UpdateTaskCommand();

        // Assert
        Assert.Equal(Guid.Empty, command.Id);
        Assert.Null(command.Title);
        Assert.Null(command.Description);
        Assert.False(command.IsCompleted);
    }
}
