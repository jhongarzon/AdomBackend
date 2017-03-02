using Adom.Hhm.Domain.Services.Security.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Domain.Secutiry.Repositories;
using Microsoft.AspNetCore.Authorization;
using Adom.Hhm.Utility;
using Microsoft.Extensions.Configuration;

namespace Adom.Hhm.Domain.Services.Security
{
    public class UserDomainServices : IUserDomainServices
    {
        private readonly IUserRepository repository;
        private readonly IConfigurationRoot configuration;

        public UserDomainServices(IConfigurationRoot configuration, IUserRepository repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        public ServiceResult<User> GetUserById(int userId)
        {
            var getUser = this.repository.GetUserById(userId);

            return new ServiceResult<User>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getUser
            };
        }

        public ServiceResult<IEnumerable<User>> GetUsers(int pageNumber, int pageSize)
        {
            var getUsers = this.repository.GetUsers(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<User>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getUsers
            };
        }

        public ServiceResult<User> Insert(User user)
        {
            user.Password = Encrypt.EncryptString("12345", this.configuration["KeyEncription"]);
            User emailExist = this.repository.GetUserByEmail(user.Email);

            if (emailExist == null)
            {
                var userInserted = this.repository.Insert(user);
                return new ServiceResult<User>
                {
                    Success = true,
                    Result = userInserted
                };
            }

            return new ServiceResult<User>
            {
                Success = false,
                Errors = new string[] { MessageError.EmailExists }
            };
        }

        public ServiceResult<User> Update(User user)
        {
            User emailExist = this.repository.GetUserByEmailWithoutId(user.UserId, user.Email);

            if (emailExist == null)
            {
                var updated = this.repository.Update(user);
                return new ServiceResult<User>
                {
                    Success = true,
                    Result = updated
                };
            }

            return new ServiceResult<User>
            {
                Success = false,
                Errors = new string[] { MessageError.EmailExists }
            };
        }
    }
}