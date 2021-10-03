using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net.Mail;
using Newtonsoft.Json;


namespace Wasted.Data
{
    public class RegistrationService
    { 
        public List<string> ErrMsg = new List<string>();
        public List<string> AddUserData(string NameBox, string LastNameBox, string EmailBox, string PasswordBox, List<User> users)
        {
            if( dataValid (NameBox, LastNameBox, EmailBox, PasswordBox, ErrMsg))
            {
                if(newEmail(EmailBox, users) && emailValid(EmailBox))
                {
                    users = CreateUserList(users);
                    users.Add(new User(){
                        Name = NameBox,
                        Lastname = LastNameBox,
                        Email = EmailBox,
                        Password = PasswordBox
                    });
                    writeToFile("UserData.json", users);
                    ErrMsg.Clear();
                    ErrMsg.Add("Success! Welcome to the Wasted family!");
                }
                else
                {
                    ErrMsg.Clear();
                    ErrMsg.Add("A user with given email address already exists!");
                    foreach(string line in ErrMsg)
                    {
                        Console.WriteLine("{0}", line);
                    }
                }
            }
            else
            {
                ErrMsg.Clear(); 
            }
            return ErrMsg;
        }

        public bool newEmail(string email, List<User> users1)
        {
            bool newEmail = true;
            foreach(User regUser in users1)
            {
                if(String.Equals(email, regUser.Email))
                {
                    return false;
                }
            }
            return true;
        }


        public bool emailValid(String email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public List<User> CreateUserList(List<User> users)
        {
           string json = File.ReadAllText(@"UserData.json");
            try 
            {
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            catch(Exception e)
            {
                Console.WriteLine("Problem: {0}", e);
            }
            return users;
        }

        public List<string> getErrorMess()
        {
            return ErrMsg;
        }

        public bool dataValid (string NameBox, string LastNameBox, string EmailBox, string PasswordBox, List<string> ErrorMessages)
        {
            if ( string.IsNullOrEmpty(NameBox) || string.IsNullOrEmpty(LastNameBox) || string.IsNullOrEmpty(EmailBox) || string.IsNullOrEmpty(PasswordBox))
            {
                return false;
            }
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            var hasComma = new Regex(@"[,]");
            //nameValid
            if(hasNumber.IsMatch(NameBox) || hasSymbols.IsMatch(NameBox))
            {
                Console.WriteLine("invalid name");
                ErrorMessages.Add("invalid name");
                return false;
            }
            //nameValid
            if(hasNumber.IsMatch(LastNameBox) || hasSymbols.IsMatch(LastNameBox))
            {
                Console.WriteLine("invalid lastname");
                ErrorMessages.Add("invalid lastname");
                ErrMsg = ErrorMessages;
                return false;
            }
            //emailValid
            if(hasComma.IsMatch(EmailBox))
            {
                Console.WriteLine("comma in email");
                ErrorMessages.Add("comma in email");
                ErrMsg = ErrorMessages;
                return false;
            }
            //PasswordValif
            if(!hasNumber.IsMatch(PasswordBox) 
            || !hasUpperChar.IsMatch(PasswordBox) 
            || !hasLowerChar.IsMatch(PasswordBox)
            || !hasMiniMaxChars.IsMatch(PasswordBox))
            {
                Console.WriteLine("invalid password");
                ErrorMessages.Add("invalid password");
                ErrMsg = ErrorMessages;
                return false;
            }
            return true;
        }
        public void writeToFile(string filePath, List<User> users)
        {
            try
            {
                string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e);
            }
        }
 
    }
    
}