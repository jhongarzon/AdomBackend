using Adom.Hhm.Data.Repositories;
using Adom.Hhm.Domain.Secutiry.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Data;
using Adom.Hhm.Data.Querys;
using Dapper;
using Adom.Hhm.Domain.Security.Repositories;

namespace Adom.Hhm.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection connection;

        public UserRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public User GetUserByEmail(string email)
        {
            return connection.Query<User>(UserQuerys.GetByEmail, new { Email = email }).FirstOrDefault();
        }

        public User GetUserByEmailWithoutId(int userId, string email)
        {
            return connection.Query<User>(UserQuerys.GetByEmailWithoutId, new { Email = email, UserId = userId }).FirstOrDefault();
        }

        public User GetUserById(int userId)
        {
            return connection.Query<User>(UserQuerys.GetById, new { UserId = userId }).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers(int pageNumber, int pageSize)
        {
            return connection.Query<User>(UserQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public User Insert(User user)
        {
            var id = connection.Query<int>(UserQuerys.Insert, user).Single();
            user.UserId = id;
            user.State = true;
            return user;
        }

        public User Update(User user)
        {
            var affectedRows = connection.Execute(UserQuerys.Update, user);
            return user;
        }

        public bool ChangePassword(int userId, string password)
        {
            var affectedRows = connection.Execute(UserQuerys.ChangePassword, new { UserId = userId, Password = password });
            return affectedRows > 0;
        }

        public User RecoverPassword(string email)
        {
            return connection.Query<User>(UserQuerys.RecoverPassword, new { Email = email }).FirstOrDefault();
        }
    }
}
