﻿using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Security.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(int pageNumber, int pageSize);
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsersActives();
        User GetUserById(int userId);
        User GetUserByEmail(string email);
        User GetUserByEmailWithoutId(int userId, string email);
        User Insert(User user);
        User Update(User user);
        bool ChangePassword(int userId, string password);
        User RecoverPassword(string email);
    }
}
