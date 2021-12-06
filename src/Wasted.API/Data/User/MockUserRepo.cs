using Wasted.API.Models;
using System.Collections.Generic;

namespace Wasted.API.Data
{
    public class MockUserRepo : IUserRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<User> GetUserList()
        {
            List<User> user = new List<User>
            {
                new User { Id = 0, Password = "PassW0rd", Email = "one@mail.com", FirstName = "Alan", LastName = "Smith", Role = "admin" },
                new User { Id = 1, Password = "PassW0rd", Email = "two@mail.com", FirstName = "John", LastName = "Crosby", Role = "user" },
                new User { Id = 2, Password = "PassW0rd", Email = "three@mail.com", FirstName = "Catherine", LastName = "Whelan", Role = "user" }
            };
            return user;
        }

        public User GetUserById(int id)
        {
            return new User { Id = 0, Password = "PassW0rd", Email = "three@mail.com", FirstName = "Catherine", LastName = "Whelan", Role = "user" };
        }
        public User GetUserByEmail(string email)
        {
            return new User { Id = 0, Password = "PassW0rd", Email = "three@mail.com", FirstName = "Catherine", LastName = "Whelan", Role = "user" };
        }


        public void CreateNewUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
