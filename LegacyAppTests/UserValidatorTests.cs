using LegacyApp;

namespace LegacyAppTests
{
    public class UserValidatorTests
    {
        private readonly UserValidator _validator = new UserValidator();
        
        [Fact]
        public void ValidateEmail_Should_Return_True_When_Email_Contains_At_And_Dot()
        {
            // Arrange
            var email = "johndoe@gmail.com";

            // Act
            bool result = _validator.ValidateEmail(email);

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void ValidateEmail_Should_Return_False_When_Email_Without_At_And_Dot()
        {
            // Arrange
            var email = "abcwppl";

            // Act
            bool result = _validator.ValidateEmail(email);

            // Assert
            Assert.False(result);
        }
        
        [Fact]
        public void ValidateName_Should_Return_True_When_Name_Is_Not_Empty()
        {
            // Arrange
            var name = "John";

            // Act
            bool result = _validator.ValidateName(name);

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void ValidateName_Should_Return_False_When_Name_Is_Empty()
        {
            // Arrange
            var name = "";

            // Act
            bool result = _validator.ValidateName(name);

            // Assert
            Assert.False(result);
        }
    }
}