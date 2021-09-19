using System.Text.RegularExpressions;
    public class User
    {
        public string Name {get; set; }
        public string Lastname {get; set; }
        public string Email {get; set; }
        public string Password{get; set; }
//Function prepared for further work with password validation
        public bool validPasswordProvided(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            
            if(   !hasLowerChar.IsMatch(password)
                ||!hasUpperChar.IsMatch(password)
                ||!hasMiniMaxChars.IsMatch(password)
                ||!hasLowerChar.IsMatch(password)
                ||!hasSymbols.IsMatch(password)
                )
                {
                    return false;
                }
            else return true;
        }
    }
