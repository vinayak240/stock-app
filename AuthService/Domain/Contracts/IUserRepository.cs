using AuthService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Domain.Contracts
{
    public interface IUserRepository
    {
        bool AddUser(User user);

        User GetUserDetails(string username);

        bool UpdateUser(User user);
    }
}
