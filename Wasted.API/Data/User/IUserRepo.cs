using Wasted.API.Models;
using System.Collections.Generic;

namespace Wasted.API.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();
        IEnumerable<User> GetUserList();
        User GetUserById(int id);
        User GetUserByLogin(string login);
        void CreateNewUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
