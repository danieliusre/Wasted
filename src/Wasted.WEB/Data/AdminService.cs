using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Serilog;
using System.IO;

namespace Wasted.Data
{


    class AdminService
    {   
        private JsonFileService _jsonFileService = new JsonFileService();

        public List<User> removeUser(string userToRemove)
        {
            List<User> users = GetUserList();
            {
                foreach (User user in users)
                {
                    if(user.Email == userToRemove)
                    {
                        users.Remove(user);
                    }   
                }
            }

            writeToFile("UserData.json", users);
            foreach (User user in users)
            {
                Console.WriteLine("{0}", user.Email);
            }
            Console.WriteLine("{0} removed from the list", userToRemove);
            return users;
        }
        public List<User> GetUserList()
        {
            List<User>users = new List<User>();
            try 
            {
                Log.Information("Starting to CreateUserList in AdminService");
                string json = _jsonFileService.ReadJsonFromFile(@"UserData.json");
                users = JsonConvert.DeserializeObject<List<User>>(json);
                Log.Information("Finished to CreateUserList in AdminService");
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

        public void writeToFile(string filePath, List<User> fileUsers)
        {
            try
            {
                Log.Information("Starting to writeToFile(AdminService)");
                string json = JsonConvert.SerializeObject(fileUsers, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Log.Information("Finished writing to file(AdminService)");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught {0}", e);
            }
        }
        public List<User> ChangeRole (string email, string role, List<User> users)
        {
            try
            {
                Log.Information("Starting to changeRole");
                 foreach (User user in users)
                {
                    if(user.Email == email)
                    {
                        switch (role)
                        {
                            case "admin":
                                user.Role = "user";
                                break;
                            case "user":
                                user.Role = "admin";
                                break;
                        }
                    }
                }
                writeToFile("UserData.json", users);
                Log.Information("Finished changeRole");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}", e);
            }
            return users;
        }


    }
}