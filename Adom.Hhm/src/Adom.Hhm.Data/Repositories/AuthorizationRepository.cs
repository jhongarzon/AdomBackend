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
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly IDbConnection connection;

        public AuthorizationRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<Policy> GetPolicies()
        {
            return connection.Query<Policy>(AuthorizationQuerys.GetPolicies);
        }

        public IEnumerable<Policy> GetPoliciesByUser(User user)
        {
            return connection.Query<Policy>(AuthorizationQuerys.GetPoliciesByUser, new { UserId = user.UserId });
        }

        public bool IsAuthorized(int userId, string route)
        {
            Resource resource = connection.Query<Resource>(AuthorizationQuerys.IsAuthorized, new { UserId = userId, RoutePath = route }).FirstOrDefault();

            if (resource != null)
            {
                return true;
            }

            return false;
        }
    }
}
