using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordValidator
{
    public class PasswordValidator
    {
        public static bool ValidatePassword(string password)
        {
            // Check if password meets all requirements
            return HasMinimumLength(password, 8) &&
                   HasLowercaseCharacter(password) &&
                   HasUppercaseCharacter(password) &&
                   HasSpecialCharacter(password) &&
                   HasDigit(password);
        }
        private static bool HasMinimumLength(string password, int minLength)
        {
            return password.Length >= minLength;
        }
        private static bool HasLowercaseCharacter(string password)
        {
            return password.Any(char.IsLower);
        }

        private static bool HasUppercaseCharacter(string password)
        {
            return password.Any(char.IsUpper);
        }

        private static bool HasSpecialCharacter(string password)
        {
            // Define the set of special characters
            string specialCharacters = "!@#$%^&*()-+";
            return password.Any(c => specialCharacters.Contains(c));
        }

        private static bool HasDigit(string password)
        {
            return password.Any(char.IsDigit);
        }

    }
}