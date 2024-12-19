using TaskList.Application.Features.TasksManagement.Commands;
using Xunit;

namespace TaskList.Test.Features;

public class CreateTaskCommandTests
{
    [Fact]
    public void CreateTaskCommand_Should_Set_Properties_Correctly()
    {
        // Arrange
        var title = "Test Title";
        var description = "Test Description";

        // Act
        var command = new CreateTaskCommand
        {
            Title = title,
            Description = description
        };

        // Assert
        Assert.Equal(title, command.Title);
        Assert.Equal(description, command.Description);
    }

    [Fact]
    public void CreateTaskCommand_Should_Allow_Null_Title_And_Description()
    {
        // Arrange
        string? title = null;
        string? description = null;

        // Act
        var command = new CreateTaskCommand
        {
            Title = title!,
            Description = description!
        };

        // Assert
        Assert.Null(command.Title);
        Assert.Null(command.Description);
    }
}