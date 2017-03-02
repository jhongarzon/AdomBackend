using Adom.Hhm.Data.Repositories;
using Adom.Hhm.Domain.Secutiry.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Adom.Hhm.Data.Querys;
using Dapper;
using System.Data;

namespace Adom.Hhm.Data.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IDbConnection connection;

        public AuthenticationRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public User ValidCredentials(string email, string password)
        {
            return connection.Query<User>(AuthenticationQuerys.ValidCredentials, new { Email = email, Password = password }).FirstOrDefault();
        }
    }
}
