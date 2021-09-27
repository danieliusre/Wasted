using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Text.Json;

namespace Wasted.Data
{
    public class RegistrationService
    {
        public List<string> ErrMsg = new List<string> ();
        public List<User> AddUserData(string NameBox, string LastNameBox, string EmailBox, string PasswordBox, List<User> users, List<string> ErrorMessages)
        {
            
            if( dataValid (NameBox, LastNameBox, EmailBox, PasswordBox, ErrorMessages) 
                           && !(string.IsNullOrEmpty(NameBox) 
                           || string.IsNullOrEmpty(LastNameBox) 
                           || string.IsNullOrEmpty(EmailBox) 
                           || string.IsNullOrEmpty(PasswordBox)))
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
                    //working with both files for now, will transfer to json only
                    string json1 = JsonSerializer.Serialize(users);
                    File.WriteAllText(@"UserData.json", json1);
                    File.AppendAllText(@"UserData.txt", NameBox + "," + LastNameBox + "," + EmailBox + "," + PasswordBox + Environment.NewLine);
                    users.Clear();
                    users = CreateUserList(users); 
                    ErrorMessages.Clear();
                    ErrorMessages.Add("Success! Welcome to the Wasted family!");
                    ErrMsg = ErrorMessages;
                    FormatJson();
                }
                else
                {
                    ErrorMessages.Clear();
                    ErrorMessages.Add("A user with given email address already exists!");
                    ErrMsg = ErrorMessages;
                    foreach(string line in ErrMsg)
                    {
                        Console.WriteLine("{0}", line);
                    }
                }
            }
            else
            {
                ErrorMessages.Clear(); 
                ErrMsg = ErrorMessages;  
            }
            return users;
        } 


        public bool newEmail(string email, List<User> users)
        {
            bool newEmail = true;
            foreach(User regUser in users)
            {
                if(String.Equals(email, regUser.Email))
                {
                    newEmail = false;
                }
            }
            return newEmail;
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
            string[] lines = System.IO.File.ReadAllLines(@"UserData.txt");   
            foreach(string line in lines) 
            {

                string[] userData = line.Split(',');
                users.Add(new User()
                {   Name = userData[0],
                    Lastname = userData[1],
                    Email = userData[2],
                    Password = userData[3]
                });
            } 
            return users;
        }

        public List<string> getErrorMess()
        {
            return ErrMsg;
        }

        public bool dataValid (string NameBox, string LastNameBox, string EmailBox, string PasswordBox, List<string> ErrorMessages)
        {
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
    //function for further work
        public void FormatJson()
        {
            string jsonString = File.ReadAllText("UserData.json"); 
            var writerOptions = new JsonWriterOptions
            {
                Indented = true
            };

            var documentOptions = new JsonDocumentOptions
            {
                CommentHandling = JsonCommentHandling.Skip
            };

            using FileStream fs = File.Create("UserDataFormated.json");
            using var writer = new Utf8JsonWriter(fs, options: writerOptions);
            using JsonDocument document = JsonDocument.Parse(jsonString, documentOptions);

            JsonElement root = document.RootElement;

        if (root.ValueKind == JsonValueKind.Object)
            {
                writer.WriteStartObject();
            }
            else
            {
                return;
            }

            foreach (JsonProperty property in root.EnumerateObject())
            {
                property.WriteTo(writer);
            }

            writer.WriteEndObject();

            writer.Flush(); 
        }
    }
    
}