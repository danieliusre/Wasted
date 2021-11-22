using Wasted.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wasted.API.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly WastedContext _context;

        public SqlUserRepo(WastedContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<User> GetUserList()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.UserId == id);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(p => p.Email == email);
        }

        public void CreateNewUser(User user)
        {
            if (user == null){
                throw new ArgumentException(nameof(user));
            }

            _context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            //Nothing
            // Possible for the change of password
            /*
            foreach(User user2 in _context.Users)
            {
                if(user2.Email == user.Email)
                {
                    user2 = user;
                }
            }
            */
        }

        public void DeleteUser(User user)
        {
            if (user == null){
                throw new ArgumentException(nameof(user));
            }

            _context.Users.Remove(user);
        }
    }
}
