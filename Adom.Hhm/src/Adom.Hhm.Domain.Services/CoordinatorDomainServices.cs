using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Microsoft.Extensions.Configuration;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Domain.Secutiry.Repositories;
using Adom.Hhm.Utility;

namespace Adom.Hhm.Domain.Services
{
    public class CoordinatorDomainServices : ICoordinatorDomainService
    {
        private readonly ICoordinatorRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IConfigurationRoot _configuration;
        private readonly IMailService _mailService;
        private readonly IUserRoleRepository _userRoleRepository;

        public CoordinatorDomainServices(IConfigurationRoot configuration, ICoordinatorRepository repository,
            IMailService mailService, IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mailService = mailService;
            _configuration = configuration;
            _userRoleRepository = userRoleRepository;
        }

        public ServiceResult<Coordinator> GetCoordinatorById(int coordinatorId)
        {
            var getCoordinator = _repository.GetCoordinatorById(coordinatorId);

            return new ServiceResult<Coordinator>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = getCoordinator
            };
        }

        public ServiceResult<IEnumerable<Coordinator>> GetCoordinators(int pageNumber, int pageSize)
        {
            var getCoordinators = _repository.GetCoordinators(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<Coordinator>>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = getCoordinators
            };
        }

        public ServiceResult<IEnumerable<Coordinator>> GetCoordinators()
        {
            var getCoordinators = _repository.GetCoordinators();
            return new ServiceResult<IEnumerable<Coordinator>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getCoordinators
            };
        }

        public ServiceResult<Coordinator> Insert(Coordinator coordinator)
        {
            var emailExist = _repository.GetCoordinatorByEmail(coordinator.Email);
            const string defaultPassword = "12345";
            if (emailExist == null)
            {
                var user = new User
                {
                    Email = coordinator.Email,
                    FirstName = coordinator.FirstName,
                    SecondName = coordinator.SecondName,
                    Surname = coordinator.Surname,
                    SecondSurname = coordinator.SecondSurname,
                    Password = Encrypt.EncryptString(defaultPassword, _configuration["KeyEncription"])
                };
                var userInserted = _userRepository.Insert(user);
                user.UserId = userInserted.UserId;
                coordinator.UserId = user.UserId;
                var coordinatorInserted = _repository.Insert(coordinator);
                if (coordinatorInserted != null && coordinatorInserted.UserId > 0)
                {
                    var userRole = new UserRole
                    {
                        UserId = coordinator.UserId,
                        RoleId = 6
                    };
                    _userRoleRepository.Insert(userRole);
                    var mailMessage = new MailMessage
                    {
                        Body = string.Format("A continuación se listan los datos de ingreso para su cuenta en Blue: <br/><br/>" +
                              "Usuario: <b>{0}</b> <br/> Password: <b>{1}</b> <br/>", user.Email, defaultPassword),
                        Subject = "Creación de usuario Blue",
                        To = new MailAccount(user.FirstName, user.Email)

                    };
                    _mailService.SendMail(mailMessage);
                }
                return new ServiceResult<Coordinator>
                {
                    Success = true,
                    Result = coordinatorInserted
                };
            }

            return new ServiceResult<Coordinator>
            {
                Success = false,
                Errors = new string[] { MessageError.EmailExists }
            };
        }

        public ServiceResult<Coordinator> Update(Coordinator coordinator)
        {
            var emailExist = _repository.GetCoordinatorByEmailWithoutId(coordinator.CoordinatorId, coordinator.Email);

            if (emailExist == null)
            {
                var user = new User();
                user.Email = coordinator.Email;
                user.FirstName = coordinator.FirstName;
                user.SecondName = coordinator.SecondName;
                user.Surname = coordinator.Surname;
                user.SecondSurname = coordinator.SecondSurname;
                user.UserId = coordinator.UserId;
                var userUpdate = _userRepository.Update(user);
                var updated = _repository.Update(coordinator);
                return new ServiceResult<Coordinator>
                {
                    Success = true,
                    Result = updated
                };
            }

            return new ServiceResult<Coordinator>
            {
                Success = false,
                Errors = new string[] { MessageError.EmailExists }
            };
        }
    }
}
