using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Mail;
using Newtonsoft.Json;
using Serilog;


namespace Wasted.Data
{
    public class RegistrationService
    { 
        private JsonFileService _jsonFileService = new JsonFileService();
        public List<string> ErrMsg = new List<string>();
        public List<string> AddUserData(string NameBox, string LastNameBox, string EmailBox, string PasswordBox, List<User> users)
        {
            try
            {
                Log.Information("Starting to Registration service");
                if( dataValid (NameBox, LastNameBox, EmailBox, PasswordBox))
                {
                    if(newEmail(EmailBox, users) && emailValid(EmailBox))
                    {
                        users = CreateUserList(users);
                        users.Add(new User(){
                            Name = NameBox,
                            Lastname = LastNameBox,
                            Email = EmailBox,
                            Password = PasswordBox,
                            Role = "user"
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
                Log.Information("Finished email checking");
                return true;
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
            try 
            {
                Log.Information("Starting to CreateUserList");
                string json = _jsonFileService.ReadJsonFromFile(@"UserData.json");
                users = JsonConvert.DeserializeObject<List<User>>(json);
                Log.Information("Finished to CreateUserList");
            }
            catch(FileNotFoundException e)
            {
                Log.Error(e.Message);
            }
            catch(Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return users;
        }
        public List<User> GetUserList()
        {
            List<User> users = new List<User>();
            users = CreateUserList(users);
            return users;
        }

        public List<string> getErrorMess()
        {
            return ErrMsg;
        }

        public bool dataValid (string NameBox, string LastNameBox, string EmailBox, string PasswordBox)
        {
            ValidationService validate = new ValidationService();
            try
            {
                Log.Information("Starting to dataValid");
                if ( validate.EmptyFieldsPresent(NameBox, LastNameBox, EmailBox,PasswordBox))
                {
                    Log.Information("Finished dataValid (empty fields present)");
                    return false;
                }
                if(!validate.NameValid(NameBox))
                {
                    ErrMsg.Add("invalid name");
                    Log.Information("Finished dataValid (invalid name)");
                    return false;
                }
                if(!validate.NameValid(LastNameBox))
                {
                    ErrMsg.Add("invalid lastname");
                    Log.Information("Finished dataValid (invalid lastname)");
                    return false;
                }
                if(!validate.PasswordValid(PasswordBox))
                {
                    ErrMsg.Add("invalid password (must include uppercare, lowercase, 8-15 symbols, digit");
                    Log.Information("Finished dataValid (invalid password)");
                    return false;
                }
                Log.Information("Finished data validation dataValid success");
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

        public bool CheckSignIn(string SignInEmailBox, string SignInPasswordBox, List<User> users)
        {
            Log.Information("Starting to CheckSignIn");
            if(!string.IsNullOrEmpty(SignInEmailBox) && !string.IsNullOrEmpty(SignInPasswordBox))
            {
                foreach(User user in users)
                {
                    if(user.Email == SignInEmailBox)
                    {
                        if(user.Password == SignInPasswordBox)
                        {
                            Log.Information("Finished CheckSignIn");
                            return true;
                        }
                    }
                }
            }
            Log.Error("Finished CheckSignIn");
            return false;
        }

        public string getName (List<User> users, string email)
        {
            Log.Information("Starting to getName(Sign in)");
            foreach(User user in users)
            {
                if(user.Email == email)
                {
                    Log.Information("Finished getName(Sign in)-success");
                    return user.Name;
                }
            }
            Log.Information("Finished getName(Sign in)-failure");
            return "";
        }

        public string GetRole(string email, List<User> users)
        {
            foreach(var user in users)
            {
                if(email == user.Email)
                {
                    return user.Role;
                }
            }
            return "user";
        }
 
    }
    
}