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

namespace Adom.Hhm.Data.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IDbConnection connection;

        public UserRoleRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<UserRole> GetRolesByUserId(int userId)
        {
            return this.connection.Query<UserRole>(UserRoleQuerys.GetRolesByUserId, new { UserId = userId });
        }

        public bool Insert(UserRole UserRole)
        {
            var affectedRows = connection.Execute(UserRoleQuerys.Insert, UserRole);
            return affectedRows > 0;
        }

        public bool Delete(UserRole UserRole)
        {
            var affectedRows = connection.Execute(UserRoleQuerys.Delete, UserRole);
            return affectedRows > 0;
        }

        public UserRole GeUserRolByUserIdRoleID(int userId, int roleId)
        {
            return this.connection.Query<UserRole>(UserRoleQuerys.GetUserRolByUserIdRoleID, new { UserId = userId, RoleId = roleId }).FirstOrDefault();
        }
    }
}
