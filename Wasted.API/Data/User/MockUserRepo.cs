﻿using Wasted.API.Models;
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
                new User { UserId = 0, Password = "pass", Email = "mail", FirstName = "First", LastName = "Last" },
                new User { UserId = 1, Password = "pass", Email = "mail", FirstName = "First", LastName = "Last" },
                new User { UserId = 2, Password = "pass", Email = "mail", FirstName = "First", LastName = "Last" }
            };
            return user;
        }

        public User GetUserById(int id)
        {
            return new User { UserId = 0, Password = "pass", Email = "mail", FirstName = "First", LastName = "Last" };
        }
        public User GetUserByEmail(string email)
        {
            return new User { UserId = 0, Password = "pass", Email = "mail", FirstName = "First", LastName = "Last" };
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