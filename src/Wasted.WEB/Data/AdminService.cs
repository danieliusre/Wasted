using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Serilog;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace Wasted.Data
{
    class AdminService
    {   
        private readonly HttpHelper _httpHelper;
        public AdminService (HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }
        public void removeUser(int id)
        {
            try 
            {
                Log.Information("Starting to delete product email: {0}", id);
                _httpHelper.Delete(id,"user");
                Log.Information("Finished reading UserList");
                
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
        }
        public async Task<List<User>> GetUserList()
        {
            List<User> users = null;
            try 
            {
                Log.Information("Starting to read UserList");
                users =  await _httpHelper.GetList<User>("user");
                Log.Information("Finished reading UserList");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return users;
        }

        public void ChangeRole (User user)
        {
            try
            {
                Log.Information("Starting to changeRole");
                
                        switch (user.Role)
                        {
                            case "admin":
                                user.Role = "user";
                                break;
                            case "user":
                                user.Role = "admin";
                                break;
                        }
                _httpHelper.Put<User>(user, "user/"+user.Id);

                Log.Information("Finished changeRole");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}", e);
            }
        }


    }
}