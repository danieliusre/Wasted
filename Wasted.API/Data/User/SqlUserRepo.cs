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

        public User GetUserByLogin(string login)
        {
            return _context.Users.FirstOrDefault(p => p.Login == login);
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
