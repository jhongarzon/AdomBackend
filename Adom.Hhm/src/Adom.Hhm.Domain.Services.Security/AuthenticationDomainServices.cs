using Adom.Hhm.Domain.Services.Security.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Adom.Hhm.Domain.Secutiry.Repositories;
using Adom.Hhm.Utility;
using Microsoft.Extensions.Configuration;

namespace Adom.Hhm.Domain.Services.Security
{
    public class AuthenticationDomainServices : IAuthenticationDomainService
    {
        private readonly IAuthenticationRepository repository;
        private readonly IConfigurationRoot configuration;


        public AuthenticationDomainServices(IConfigurationRoot configuration, IAuthenticationRepository repository)
        {
            this.configuration = configuration;
            this.repository = repository;
        }

        public string GetNewToken(User user)
        {
            throw new NotImplementedException();
        }

        public User ValidCredentials(string email, string password)
        {
            return this.repository.ValidCredentials(email, Encrypt.EncryptString(password, this.configuration["KeyEncription"]));
        }
    }
}
