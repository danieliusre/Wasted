using System.Text.RegularExpressions;

namespace Wasted.Data
{
    public class ValidationService
    {
        Regex hasNumber = new Regex(@"[0-9]+");
        Regex hasUpperChar = new Regex(@"[A-Z]+");
        Regex hasMiniMaxChars = new Regex(@".{8,15}");
        Regex hasLowerChar = new Regex(@"[a-z]+");
        Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
        Regex hasComma = new Regex(@"[,]");

        Regex hasHTTP = new Regex(@"^(http|https)://");

        public bool EmptyFieldsPresent(string NameBox, string LastnameBox, string EmailBox, string PasswordBox)
        {
            if(string.IsNullOrEmpty(NameBox) ||  
               string.IsNullOrEmpty(LastnameBox) || 
               string.IsNullOrEmpty(EmailBox) || 
               string.IsNullOrEmpty(PasswordBox))
               {
                return true;
               }
            return false;
        }
        public bool NameValid(string NameBox)
        {
            if(hasNumber.IsMatch(NameBox) || hasSymbols.IsMatch(NameBox))
            {
                return false;
            }
            return true;
        }

        public bool NumberValid(string NumberTextField)
        {
             if(hasNumber.IsMatch(NumberTextField))
            {
                return true;
            }
            return false;
        }

        public bool LinkValid(string LinkTextField)
        {
            if(hasHTTP.IsMatch(LinkTextField))
            {
                return true;
            }
            return false;
        }
        
        public bool PasswordValid(string PasswordBox)
        {
            if(!hasNumber.IsMatch(PasswordBox) 
                || !hasUpperChar.IsMatch(PasswordBox) 
                || !hasLowerChar.IsMatch(PasswordBox)
                || !hasMiniMaxChars.IsMatch(PasswordBox))
            {
                return false;
            }
            return true;
        }
    }
}
