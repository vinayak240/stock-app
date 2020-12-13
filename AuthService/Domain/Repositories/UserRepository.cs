using AuthService.DataContext;
using AuthService.Domain.Contracts;
using AuthService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly UserDbContext context;
        public UserRepository(UserDbContext ctx)
        {
            context = ctx;
        }
        public bool AddUser(User user)
        {
            context.Users.Add(user);
            int RowsAdded = context.SaveChanges();
            return RowsAdded > 0;
        }

        public User GetUserDetails(string username)
        {
            var user = context.Users.SingleOrDefault(user => user.Username == username);
            return user;
        }

        public bool UpdateUser(User user)
        {
            var Obj = GetUserDetails(user.Username);
            //Obj.Name = user.Name;
            Obj.Password = user.Password;
            Obj.Email = user.Email;
            Obj.Confirmed = (Obj.Email == user.Email);
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }
    }
}
