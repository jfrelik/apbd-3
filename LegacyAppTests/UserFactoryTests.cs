using LegacyApp;

namespace LegacyAppTests
{
    public class UserFactoryTests
    {
        private readonly UserFactory _userFactory = new UserFactory(new UserCreditService());

        [Fact]
        public void CreateUser_Should_Return_User_With_CreditLimit_When_Client_Is_ImportantClient()
        {
            // Arrange
            var client = new Client{Type = "ImportantClient"};
            var user = _userFactory.CreateUser("John", "Doe", "123@wp.pl", new DateTime(1990, 1, 1), client);

            // Act
            bool result = user.HasCreditLimit;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CreateUser_Should_Return_User_With_CreditLimit_Multiplied_By_Two_When_Client_Is_ImportantClient()
        {
            // Arrange
            var client = new Client{Type = "ImportantClient"};
            var user = _userFactory.CreateUser("John", "Doe", "123@wp.pl", new DateTime(2000, 1, 1), client);

            // Act
            int result = user.CreditLimit;

            // Assert
            Assert.Equal(6000, result);
        }

        [Fact]
        public void CreateUser_Should_Return_User_With_CreditLimit_When_Client_Is_Not_ImportantClient()
        {
            // Arrange
            var client = new Client{Type = "NotImportantClient"};
            var user = _userFactory.CreateUser("John", "Doe", "123@wp.pl", new DateTime(1990, 1, 1), client);

            // Act
            bool result = user.HasCreditLimit;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CreateUser_Should_Return_User_With_CreditLimit_When_Client_Is_VeryImportantClient()
        {
            // Arrange
            var client = new Client{Type = "VeryImportantClient"};
            var user = _userFactory.CreateUser("John", "Doe", "123@wp.pl", new DateTime(1990, 1, 1), client);

            // Act
            bool result = user.HasCreditLimit;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CreateUser_Should_Return_User_With_CreditLimit_When_Client_Is_VeryImportantClient_And_CreditLimit_Is_Zero()
        {
            // Arrange
            var client = new Client{Type = "VeryImportantClient"};
            var user = _userFactory.CreateUser("John", "Doe", "123@wp.pl", new DateTime(2000, 1, 1), client);

            // Act
            int result = user.CreditLimit;

            // Assert
            Assert.Equal(0, result);
        }
    }
}