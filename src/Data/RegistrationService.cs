using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net.Mail;
using Newtonsoft.Json;
using Serilog;


namespace Wasted.Data
{
    public class RegistrationService
    { 
        public List<string> ErrMsg = new List<string>();
        public List<string> AddUserData(string NameBox, string LastNameBox, string EmailBox, string PasswordBox, List<User> users)
        {
            try
            {
                Log.Information("Starting to Registration service");
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
                    }
                }
                else
                {
                    ErrMsg.Clear(); 
                }
                Log.Information("Finished Registration service");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}", e);
            }
            return ErrMsg;
        }

        public bool newEmail(string email, List<User> users1)
        {
            try
            {
                Log.Information("Starting to newEmail check");
                foreach(User regUser in users1)
                {
                    if(String.Equals(email, regUser.Email))
                    {
                        return false;
                    }
                }
                return true;
                Log.Information("Finished email checking");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught {0}", e);
                return false;
            }
        }


        public bool emailValid(String email)
        {
            try
            {
                Log.Information("Starting emailValid");
                MailAddress m = new MailAddress(email);
                Log.Information("Finished emailValid");

                return true;
            }
            catch (FormatException e)
            {
                Log.Error("Exception caught: {0}", e);
                return false;
            }
        }

        public List<User> CreateUserList(List<User> users)
        {
           string json = File.ReadAllText(@"UserData.json");
            try 
            {
                Log.Information("Starting to CreateUserList");
                users = JsonConvert.DeserializeObject<List<User>>(json);
                Log.Information("Finished to CreateUserList");
            }
            catch(Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return users;
        }

        public List<string> getErrorMess()
        {
            return ErrMsg;
        }

        public bool dataValid (string NameBox, string LastNameBox, string EmailBox, string PasswordBox, List<string> ErrorMessages)
        {
            try
            {
                Log.Information("Starting to dataValid");
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
                Log.Information("Finished data validation dataValid");
                return true;
            }
            catch (Exception e)
            {
                Log.Error("Exception caught:{0}",e);
                return false;
            }

        }
        public void writeToFile(string filePath, List<User> users)
        {
            try
            {
                Log.Information("Starting to writeToFile(RegisteringService)");
                string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Log.Information("Finished writing to file");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught {0}", e);
            }
        }
 
    }
    
}