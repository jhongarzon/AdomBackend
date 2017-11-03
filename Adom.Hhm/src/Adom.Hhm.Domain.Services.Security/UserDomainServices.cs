using Adom.Hhm.Domain.Services.Security.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Domain.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Adom.Hhm.Utility;
using Microsoft.Extensions.Configuration;

namespace Adom.Hhm.Domain.Services.Security
{
    public class UserDomainServices : IUserDomainServices
    {
        private readonly IUserRepository _repository;
        private readonly IConfigurationRoot _configuration;
        private readonly IMailService _mailService;

        public UserDomainServices(IConfigurationRoot configuration, IUserRepository repository, IMailService mailService)
        {
            _repository = repository;
            _configuration = configuration;
            _mailService = mailService;
        }

        public ServiceResult<User> GetUserById(int userId)
        {
            var getUser = _repository.GetUserById(userId);

            return new ServiceResult<User>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = getUser
            };
        }

        public ServiceResult<IEnumerable<User>> GetUsers(int pageNumber, int pageSize)
        {
            var getUsers = _repository.GetUsers(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<User>>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = getUsers
            };
        }

        public ServiceResult<IEnumerable<User>> GetUsers()
        {
            var getUsers = _repository.GetUsers();
            return new ServiceResult<IEnumerable<User>>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = getUsers.OrderBy(x => x.UserId)
            };
        }

        public ServiceResult<IEnumerable<User>> GetUsersActive()
        {
            var getUsers = _repository.GetUsersActives();
            return new ServiceResult<IEnumerable<User>>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = getUsers
            };
        }

        public ServiceResult<User> Insert(User user)
        {
            const string defaultPassword = "12345";
            user.Password = Encrypt.EncryptString(defaultPassword, _configuration["KeyEncription"]);
            var emailExist = _repository.GetUserByEmail(user.Email);

            if (emailExist == null)
            {
                var userInserted = _repository.Insert(user);
                if (userInserted.UserId > 0)
                {
                    var mailMessage = new MailMessage
                    {
                        Body = string.Format("A continuación se listan los datos de ingreso para su cuenta en Blue: <br/><br/>" +
                              "Usuario: <b>{0}</b> <br/> Password: <b>{1}</b> <br/>", user.Email, defaultPassword),
                        Subject = "Creación de usuario Blue",
                        To = new MailAccount(user.FirstName, user.Email)

                    };
                    _mailService.SendMail(mailMessage);
                }
                return new ServiceResult<User>
                {
                    Success = true,
                    Result = userInserted
                };
            }

            return new ServiceResult<User>
            {
                Success = false,
                Errors = new[] { MessageError.EmailExists }
            };
        }

        public ServiceResult<User> Update(User user)
        {
            var emailExist = _repository.GetUserByEmailWithoutId(user.UserId, user.Email);

            if (emailExist == null)
            {
                var updated = _repository.Update(user);
                return new ServiceResult<User>
                {
                    Success = true,
                    Result = updated
                };
            }

            return new ServiceResult<User>
            {
                Success = false,
                Errors = new[] { MessageError.EmailExists }
            };
        }

        public ServiceResult<bool> ChangePassword(int userId, string password)
        {
            var encryptedPassword = Encrypt.EncryptString(password, _configuration["KeyEncription"]);
            var result = _repository.ChangePassword(userId, encryptedPassword);

            if (result)
            {
                var user = _repository.GetUserById(userId);
                var mailMessage = new MailMessage
                {
                    Body = string.Format("HOLA, {0} <br/>" +
                                         "Estos son tus nuevos datos de acceso a Blue: <br/><br/>" +
                          "Usuario: <b>{1}</b> <br/> Contraseña: <b>{2}</b> <br/>", user.NamesComplete, user.Email, password),
                    Subject = "Cambio de contraseña - ADOM",
                    To = new MailAccount(user.FirstName, user.Email)

                };
                _mailService.SendMail(mailMessage);
            }

            return new ServiceResult<bool>
            {
                Success = true,
                Result = result
            };
        }

        public ServiceResult<User> RecoverPassword(string email)
        {
            var user = _repository.RecoverPassword(email);

            if (user != null)
            {
                user.Password = Encrypt.DecryptDecryptString(user.Password, _configuration["KeyEncription"]);
                var mailMessage = new MailMessage
                {
                    Body = string.Format("Su contraseña ha sido recuperada. <br/> " +
                                         "Los datos de ingreso para su cuenta en Blue son: <br/><br/>" +
                          "Usuario: <b>{0}</b> <br/> Contraseña: <b>{1}</b> <br/>", user.Email, user.Password),
                    Subject = "Recuperación de contraseña Blue",
                    To = new MailAccount(user.FirstName, user.Email)

                };
                _mailService.SendMail(mailMessage);
                return new ServiceResult<User>
                {
                    Success = true,
                    Result = user
                };
            }

            return new ServiceResult<User>
            {
                Success = false,
                Errors = new[] { MessageError.UserNotExist }
            };
        }
    }
}
