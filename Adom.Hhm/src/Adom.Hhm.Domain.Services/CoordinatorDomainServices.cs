using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Microsoft.Extensions.Configuration;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Utility;

namespace Adom.Hhm.Domain.Services
{
    public class CoordinatorDomainServices : ICoordinatorDomainService
    {
        private readonly ICoordinatorRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public CoordinatorDomainServices(IConfigurationRoot configuration, ICoordinatorRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public ServiceResult<Coordinator> GetCoordinatorById(int coordinatorId)
        {
            var getCoordinator = this.repository.GetCoordinatorById(coordinatorId);

            return new ServiceResult<Coordinator>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getCoordinator
            };
        }

        public ServiceResult<IEnumerable<Coordinator>> GetCoordinators(int pageNumber, int pageSize)
        {
            var getCoordinators = this.repository.GetCoordinators(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<Coordinator>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getCoordinators
            };
        }

        public ServiceResult<Coordinator> Insert(Coordinator coordinator)
        {
            Coordinator emailExist = this.repository.GetCoordinatorByEmail(coordinator.Email);

            if (emailExist == null)
            {
                User user = new User();
                user.Email = coordinator.Email;
                user.FirstName = coordinator.FirstName;
                user.SecondName = coordinator.SecondName;
                user.Surname = coordinator.Surname;
                user.SecondSurname = coordinator.SecondSurname;
                user.Password = Encrypt.EncryptString("12345", this.configuration["KeyEncription"]);
                var userInserted = this.userRepository.Insert(user);
                user.UserId = userInserted.UserId;
                coordinator.UserId = user.UserId;
                var CoordinatorInserted = this.repository.Insert(coordinator);
                return new ServiceResult<Coordinator>
                {
                    Success = true,
                    Result = CoordinatorInserted
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
            Coordinator emailExist = this.repository.GetCoordinatorByEmailWithoutId(coordinator.CoordinatorId, coordinator.Email);

            if (emailExist == null)
            {
                User user = new User();
                user.Email = coordinator.Email;
                user.FirstName = coordinator.FirstName;
                user.SecondName = coordinator.SecondName;
                user.Surname = coordinator.Surname;
                user.SecondSurname = coordinator.SecondSurname;
                user.UserId = coordinator.UserId;
                var userUpdate = this.userRepository.Update(user);
                var updated = this.repository.Update(coordinator);
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
