using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using Serilog;
using System.Linq;

namespace Wasted.Data
{
    
    public class RegistrationService
    { 
        private readonly HttpHelper _httpHelper;

        public RegistrationService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }
        public List<string> ErrMsg = new List<string>();
        public async Task<List<string>> AddUserData(string NameBox, string LastNameBox, string EmailBox, string PasswordBox)
        {
            List<User> users = new List<User>(await _httpHelper.GetList<User>("user")); ;
            try
            {
                Log.Information("Starting to Registration service");
                if( dataValid (NameBox, LastNameBox, EmailBox, PasswordBox))
                {
                    if (emailValid(EmailBox))
                    {
                        if (newEmail(EmailBox, users))
                        {
                            //users = await GetUserList();
                            User user = new();

                            user.FirstName = NameBox;
                            user.Lastname = LastNameBox;
                            user.Email = EmailBox;
                            user.Password = PasswordBox;
                            user.Role = "user";

                            var id = await _httpHelper.Post<User>(user, "user");
                            ErrMsg.Clear();
                            ErrMsg.Add("Success! Welcome to the Wasted family!");
                        }
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
                Log.Information("Starting to newEmail check");
                var usedEmail = users1.Where(x => x.Email == email).FirstOrDefault();
                if (usedEmail == null)
                {
                    Console.WriteLine(usedEmail);
                    foreach (User u in users1)
                {
                    Log.Information(u.FirstName, u.Email);
                }    
                    Log.Information("Finished email checking {usedEmail}");
                    return true;
                }
                else
                {
                    Log.Error("Email is already in use");
                ErrMsg.Clear();
                ErrMsg.Add("A user with given email address already exists!");
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

        public async Task<List<User>> GetUserList()
        {
            List<User> users = new();
            try 
            {
                Log.Information("Starting to read UserList");
                users =  new List<User>(await _httpHelper.GetList<User>("user"));
                Log.Information("Finished reading UserList");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
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
        public async Task<int> GetUserId(string email)
        {
            var users =  await GetUserList();
            return users.Where(x => x.Email == email).Select(x => x.Id).FirstOrDefault();
            
        }
 
    }
    
}