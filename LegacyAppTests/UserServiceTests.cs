using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        // Arrange
        var userService = new UserService();

        // Act
        bool result = userService.AddUser("John", "Doe", "invalidemail", new DateTime(1990, 1, 1), 1);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Name_Is_Empty()
    {
        // Arrange
        var userService = new UserService();

        // Act
        bool result = userService.AddUser("", "Doe", "123@wp.pl", new DateTime(1990, 1, 1), 1);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Email_Contains_At_And_Dot_And_Name_Is_Not_Empty()
    {
        // Arrange
        var userService = new UserService();

        // Act
        bool result = userService.AddUser("John", "Doe", "123@wp.pl", new DateTime(1990, 1, 1), 1);

        // Assert
        Assert.True(result);
    }
    
}