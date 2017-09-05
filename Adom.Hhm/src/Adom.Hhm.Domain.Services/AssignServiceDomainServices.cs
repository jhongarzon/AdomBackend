using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Microsoft.Extensions.Configuration;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Utility;
using System;

namespace Adom.Hhm.Domain.Services
{
    public class AssignServiceDomainServices : IAssignServiceDomainService
    {
        private readonly IAssignServiceRepository _repository;
        private readonly IMailService _mailService;
        private readonly IProfessionalRepository _professionalRepository;
        private readonly IServiceRepository _serviceRepository;

        public AssignServiceDomainServices(IAssignServiceRepository repository, IMailService mailService,
            IProfessionalRepository professionalRepository, IServiceRepository serviceRepository)
        {
            _repository = repository;
            _mailService = mailService;
            _professionalRepository = professionalRepository;
            _serviceRepository = serviceRepository;
        }

        public ServiceResult<AssignService> GetAssignServiceById(int assignServiceId)
        {
            var getAssignService = _repository.GetAssignServiceById(assignServiceId);

            return new ServiceResult<AssignService>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignService
            };
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServiceByPatientId(int patientId)
        {
            var getAssignService = _repository.GetAssignServiceByPatientId(patientId);

            return new ServiceResult<IEnumerable<AssignService>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignService
            };
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServices(int pageNumber, int pageSize)
        {
            var getAssignServices = _repository.GetAssignServices(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<AssignService>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServices
            };
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServices()
        {
            var getAssignServices = _repository.GetAssignServices();
            return new ServiceResult<IEnumerable<AssignService>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServices
            };
        }

        public ServiceResult<AssignService> Insert(AssignService assignService)
        {
            var assignServiceInserted = _repository.Insert(assignService);
            if (assignServiceInserted.AssignServiceId > 0)
            {
                if (assignService.ProfessionalId > 0)
                {
                    var professional = _professionalRepository.GetProfessionalById(assignService.ProfessionalId);
                    var service = _serviceRepository.GetServiceById(assignService.ServiceId);
                    var mailMessage = new MailMessage
                    {

                        Body =
                            $"Buen día Sr(a): {professional.FirstName} <br/><br/>" +
                            $"Se le ha asignado el servicio {service.Name}, con fecha de inicio {assignService.InitialDate} y fecha final {assignService.FinalDate} ",
                        Subject = "Asignación de servicio",
                        To = new MailAccount(professional.FirstName, professional.Email)

                    };
                    _mailService.SendMail(mailMessage);
                }
                
            }
            return new ServiceResult<AssignService>
            {
                Success = true,
                Result = assignServiceInserted
            };
        }

        public ServiceResult<AssignService> Update(AssignService assignService)
        {
            var updated = _repository.Update(assignService);
            return new ServiceResult<AssignService>
            {
                Success = true,
                Result = updated
            };
        }

        public ServiceResult<string> CalculateFinalDateAssignService(int quantity, int serviceFrecuencyId, string initialDate)
        {
            var finalDateAssignService = _repository.CalculateFinalDateAssignService(quantity, serviceFrecuencyId, initialDate);
            return new ServiceResult<string>
            {
                Success = true,
                Result = finalDateAssignService
            };
        }
    }
}
