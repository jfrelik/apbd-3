using LegacyApp.Interfaces;
using System;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserCreditService _userCreditService;
        private readonly UserValidator _validator;
        private readonly UserFactory _userFactory;


        [Obsolete("Will be removed in the 0.2")]
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
            _validator = new UserValidator();
            _userFactory = new UserFactory(_userCreditService);
        }

        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
        }

        private int CalculateUserAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            // Go back to the year the person was born in case of a leap year
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age;
        }
        
        private bool IsUserBelowCreditLimit(User user)
        {
            return user.HasCreditLimit && user.CreditLimit <= 500;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_validator.ValidateName(firstName) || !_validator.ValidateName(lastName) || !_validator.ValidateEmail(email)) return false;
            
            int age = CalculateUserAge(dateOfBirth);
            if (age < 21) return false;

            var client = _clientRepository.GetById(clientId);
            var user = _userFactory.CreateUser(firstName, lastName, email, dateOfBirth, client);
            
            if (IsUserBelowCreditLimit(user)) return false;

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}