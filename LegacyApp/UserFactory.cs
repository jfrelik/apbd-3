using LegacyApp.Interfaces;
using System;

namespace LegacyApp
{
    public class UserFactory
    {
        private readonly IUserCreditService _userCreditService;

        public UserFactory(IUserCreditService userCreditService)
        {
            _userCreditService = userCreditService;
        }

        public User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
        {
            var user = new User{
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
                return user;
            }

            user.HasCreditLimit = true; // Assume default is to have a limit 
            int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);

            if (client.Type == "ImportantClient")
            {
                creditLimit *= 2;
            }

            user.CreditLimit = creditLimit;

            return user;
        }
    }
}