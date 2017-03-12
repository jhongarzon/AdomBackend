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
    public class ProfessionalDomainServices : IProfessionalDomainService
    {
        private readonly IProfessionalRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public ProfessionalDomainServices(IConfigurationRoot configuration, IProfessionalRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public ServiceResult<Professional> GetProfessionalById(int ProfessionalId)
        {
            var getProfessional = this.repository.GetProfessionalById(ProfessionalId);

            return new ServiceResult<Professional>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getProfessional
            };
        }

        public ServiceResult<IEnumerable<Professional>> GetProfessionals(int pageNumber, int pageSize)
        {
            var getProfessionals = this.repository.GetProfessionals(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<Professional>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getProfessionals
            };
        }

        public ServiceResult<IEnumerable<Professional>> GetProfessionals()
        {
            var getProfessionals = this.repository.GetProfessionals();
            return new ServiceResult<IEnumerable<Professional>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getProfessionals
            };
        }

        public ServiceResult<Professional> Insert(Professional professional)
        {
            Professional emailExist = this.repository.GetProfessionalByEmail(professional.Email);

            if (emailExist == null)
            {
                User user = new User();
                user.Email = professional.Email;
                user.FirstName = professional.FirstName;
                user.SecondName = professional.SecondName;
                user.Surname = professional.Surname;
                user.SecondSurname = professional.SecondSurname;
                user.Password = Encrypt.EncryptString("12345", this.configuration["KeyEncription"]);
                var userInserted = this.userRepository.Insert(user);
                user.UserId = userInserted.UserId;
                professional.UserId = user.UserId;
                var professionalInserted = this.repository.Insert(professional);
                return new ServiceResult<Professional>
                {
                    Success = true,
                    Result = professionalInserted
                };
            }

            return new ServiceResult<Professional>
            {
                Success = false,
                Errors = new string[] { MessageError.EmailExists }
            };
        }

        public ServiceResult<Professional> Update(Professional professional)
        {
            Professional emailExist = this.repository.GetProfessionalByEmailWithoutId(professional.ProfessionalId, professional.Email);

            if (emailExist == null)
            {
                User user = new User();
                user.Email = professional.Email;
                user.FirstName = professional.FirstName;
                user.SecondName = professional.SecondName;
                user.Surname = professional.Surname;
                user.SecondSurname = professional.SecondSurname;
                user.UserId = professional.UserId;
                var userUpdate = this.userRepository.Update(user);
                var updated = this.repository.Update(professional);
                return new ServiceResult<Professional>
                {
                    Success = true,
                    Result = updated
                };
            }

            return new ServiceResult<Professional>
            {
                Success = false,
                Errors = new string[] { MessageError.EmailExists }
            };
        }
    }
}
