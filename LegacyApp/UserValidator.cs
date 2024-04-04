namespace LegacyApp
{
    public class UserValidator
    {
        public bool ValidateEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        public bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name);
        }
    }
}