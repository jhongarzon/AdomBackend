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
    public class ProfessionalDomainServices : IProfessionalDomainService
    {
        private readonly IProfessionalRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IConfigurationRoot _configuration;
        private readonly IMailService _mailService;
        private readonly IUserRoleRepository _userRoleRepository;

        public ProfessionalDomainServices(IConfigurationRoot configuration, IProfessionalRepository repository,
            IMailService mailService, IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _configuration = configuration;
            _mailService = mailService;
            _userRoleRepository = userRoleRepository;
        }

        public ServiceResult<Professional> GetProfessionalById(int professionalId)
        {
            var getProfessional = _repository.GetProfessionalById(professionalId);

            return new ServiceResult<Professional>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getProfessional
            };
        }

        public ServiceResult<IEnumerable<Professional>> GetProfessionals(int pageNumber, int pageSize)
        {
            var getProfessionals = _repository.GetProfessionals(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<Professional>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getProfessionals
            };
        }

        public ServiceResult<IEnumerable<Professional>> GetProfessionals()
        {
            var getProfessionals = _repository.GetProfessionals();
            return new ServiceResult<IEnumerable<Professional>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getProfessionals
            };
        }

        public ServiceResult<Professional> Insert(Professional professional)
        {
            var emailExist = _repository.GetProfessionalByEmail(professional.Email);
            const string defaultPassword = "12345";
            if (emailExist == null)
            {
                var user = new User
                {
                    Email = professional.Email,
                    FirstName = professional.FirstName,
                    SecondName = professional.SecondName,
                    Surname = professional.Surname,
                    SecondSurname = professional.SecondSurname,
                    Password = Encrypt.EncryptString(defaultPassword, _configuration["KeyEncription"])
                };
                var userInserted = _userRepository.Insert(user);
                user.UserId = userInserted.UserId;
                professional.UserId = user.UserId;
                var professionalInserted = _repository.Insert(professional);
                if (professionalInserted != null && professionalInserted.UserId > 0)
                {
                    var userRole = new UserRole
                    {
                        UserId = professional.UserId,
                        RoleId = 14
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
            var emailExist = _repository.GetProfessionalByEmailWithoutId(professional.ProfessionalId, professional.Email);

            if (emailExist == null)
            {
                var user = new User
                {
                    Email = professional.Email,
                    FirstName = professional.FirstName,
                    SecondName = professional.SecondName,
                    Surname = professional.Surname,
                    SecondSurname = professional.SecondSurname,
                    UserId = professional.UserId
                };
                var userUpdate = _userRepository.Update(user);
                var updated = _repository.Update(professional);
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

        public ServiceResult<Professional> GetByDocument(int documentType, string document)
        {
            var getProfessional = _repository.GetByDocument(documentType, document);

            return new ServiceResult<Professional>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = getProfessional
            };
        }
    }
}
