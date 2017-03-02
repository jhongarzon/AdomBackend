using Adom.Hhm.AppServices.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Adom.Hhm.Domain.Services.Security.Interface;

namespace Adom.Hhm.AppServices.Security
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainServices service;

        public UserAppService(IUserDomainServices service)
        {
            this.service = service;
        }

        public ServiceResult<User> GetUserById(int userId)
        {
            return this.service.GetUserById(userId);
        }

        public ServiceResult<IEnumerable<User>> GetUsers(int pageNumber, int pageSize)
        {
            return this.service.GetUsers(pageNumber, pageSize);
        }

        public ServiceResult<User> Insert(User user)
        {
            return this.service.Insert(user);
        }

        public ServiceResult<User> Update(User user)
        {
            return this.service.Update(user);
        }
    }
}
