using Presenter.MessageBox;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BL.Validate
{
    internal static class ValidateAccount
    {
        private static EmailAddressAttribute emailValid = new EmailAddressAttribute();
        internal static bool EmailCheck(string email, IMessageService message)
        {
            var isValid = emailValid.IsValid(email);
            if (!isValid)
                message.Show("Incorrect email address.");
            return isValid;
        }
        internal static bool PasswordCheck(string password, IMessageService message)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasChar = new Regex(@"[A-z]+");
            var hasMiniMaxChars = new Regex(@".{6,15}");


            if (!hasMiniMaxChars.IsMatch(password))
            {
                message.Show("Password should not be less than 6 or greater than 15 characters");
                return false;
            }
            else if (!hasNumber.IsMatch(password))
            {
                message.Show("Password should contain one numeric value");
                return false;
            }

            else if (!hasChar.IsMatch(password))
            {
                message.Show("Password must contain one letter");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
