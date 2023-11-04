using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;

namespace MyBankingProject.Validation
{
    public class RegExValidation
    {
        private String emailValidationString = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

    public bool EmailValidation(string email)
        {
            if (email == null) { return false; }

            bool isEmail = Regex.IsMatch(email, emailValidationString, RegexOptions.IgnoreCase);

            return isEmail;
        }
    }
}
