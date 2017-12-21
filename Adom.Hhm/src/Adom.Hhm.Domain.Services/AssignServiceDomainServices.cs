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
        private readonly IPatientRepository _patientRepository;
        private readonly ICoPaymentFrecuencyRepository _copaymentFrecuencyRepository;
        private readonly IServiceFrecuencyRepository _serviceFrecuencyRepository;

        public AssignServiceDomainServices(IAssignServiceRepository repository, IMailService mailService,
            IProfessionalRepository professionalRepository, IServiceRepository serviceRepository,
            IPatientRepository patientRepository, ICoPaymentFrecuencyRepository coPaymentFrecuencyRepository,
            IServiceFrecuencyRepository serviceFrecuencyRepository)
        {
            _repository = repository;
            _mailService = mailService;
            _professionalRepository = professionalRepository;
            _serviceRepository = serviceRepository;
            _patientRepository = patientRepository;
            _copaymentFrecuencyRepository = coPaymentFrecuencyRepository;
            _serviceFrecuencyRepository = serviceFrecuencyRepository;

        }

        public ServiceResult<AssignService> GetAssignServiceById(int assignServiceId)
        {
            var getAssignService = _repository.GetAssignServiceById(assignServiceId);

            return new ServiceResult<AssignService>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = getAssignService
            };
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServiceByPatientId(int patientId)
        {
            var getAssignService = _repository.GetAssignServiceByPatientId(patientId);

            return new ServiceResult<IEnumerable<AssignService>>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = getAssignService
            };
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServices(int pageNumber, int pageSize)
        {
            var getAssignServices = _repository.GetAssignServices(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<AssignService>>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = getAssignServices
            };
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServices()
        {
            var getAssignServices = _repository.GetAssignServices();
            return new ServiceResult<IEnumerable<AssignService>>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = getAssignServices
            };
        }

        public ServiceResult<AssignService> Insert(AssignService assignService)
        {
            var assignServiceInserted = _repository.Insert(assignService);
            AssignmentMail(assignServiceInserted);
            return new ServiceResult<AssignService>
            {
                Success = true,
                Result = assignServiceInserted
            };
        }

        public ServiceResult<IEnumerable<ServiceObservation>> GetServiceObservations(int assignServiceId, int userId)
        {

            var serviceObservations = _repository.GetServiceObservations(assignServiceId, userId);
            return new ServiceResult<IEnumerable<ServiceObservation>>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = serviceObservations
            };
        }

        public ServiceResult<ServiceObservation> InsertObservation(ServiceObservation serviceObservation)
        {
            var currentDate = DateTime.Now;
            serviceObservation.RecordDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss");
            var assignServiceInserted = _repository.InsertObservation(serviceObservation);
            return new ServiceResult<ServiceObservation>
            {
                Success = true,
                Result = assignServiceInserted
            };
        }

        public ServiceResult<AssignService> Update(AssignService assignService)
        {
            var current = _repository.GetAssignServiceById(assignService.AssignServiceId);
            var updated = _repository.Update(assignService);
            
            if (updated.ProfessionalId != current.ProfessionalId)
            {
                AssignmentMail(updated);
                CancellationMail(current);
            }

            return new ServiceResult<AssignService>
            {
                Success = true,
                Result = updated
            };
        }

        private void AssignmentMail(AssignService assignService)
        {
            if (assignService.AssignServiceId > 0)
            {
                if (assignService.ProfessionalId > 0)
                {
                    var professional = _professionalRepository.GetProfessionalById(assignService.ProfessionalId);
                    var service = _serviceRepository.GetServiceById(assignService.ServiceId);
                    var patient = _patientRepository.GetPatientById(assignService.PatientId);
                    var professionalFullName = $" {professional.FirstName} {professional.SecondName} {professional.Surname} {professional.SecondSurname} ";
                    var patientFullName = $"{patient.FirstName} {patient.SecondName} {patient.Surname} {patient.SecondSurname} ";
                    var copaymentFrecuency = _copaymentFrecuencyRepository.GetCoPaymentFrecuencyById(assignService.CoPaymentFrecuencyId);
                    var serviceFrecuency = _serviceFrecuencyRepository.GetServiceFrecuencyById(assignService.ServiceFrecuencyId);

                    var body = string.Format(AdomMailContent.AssignServiceMailText,
                        professionalFullName,
                        patient.Document,
                        patientFullName,
                        patient.Address,
                        patient.Telephone1,
                        assignService.AuthorizationNumber,
                        service.Name,
                        assignService.InitialDate,
                        assignService.FinalDate,
                        serviceFrecuency.Name,
                        assignService.CoPaymentAmount,
                        copaymentFrecuency.Name);

                    var mailMessage = new MailMessage
                    {
                        Body = body,
                        Subject = "Nuevo servicio asignado – ADOM",
                        To = new MailAccount(professional.FirstName, professional.Email)
                    };
                    _mailService.SendMail(mailMessage);
                }
            }
        }

        private void CancellationMail(AssignService assignService)
        {
            if (assignService.AssignServiceId > 0)
            {
                if (assignService.ProfessionalId > 0)
                {
                    var professional = _professionalRepository.GetProfessionalById(assignService.ProfessionalId);
                    var service = _serviceRepository.GetServiceById(assignService.ServiceId);
                    var patient = _patientRepository.GetPatientById(assignService.PatientId);
                    var professionalFullName = $" {professional.FirstName} {professional.SecondName} {professional.Surname} {professional.SecondSurname} ";
                    var patientFullName = $"{patient.FirstName} {patient.SecondName} {patient.Surname} {patient.SecondSurname} ";
                    var copaymentFrecuency = _copaymentFrecuencyRepository.GetCoPaymentFrecuencyById(assignService.CoPaymentFrecuencyId);
                    var serviceFrecuency = _serviceFrecuencyRepository.GetServiceFrecuencyById(assignService.ServiceFrecuencyId);

                    var body = string.Format(AdomMailContent.AssignServiceMailText,
                        professionalFullName,
                        patient.Document,
                        patientFullName,
                        patient.Address,
                        patient.Telephone1,
                        assignService.AuthorizationNumber,
                        service.Name,
                        assignService.InitialDate,
                        assignService.FinalDate,
                        serviceFrecuency.Name,
                        assignService.CoPaymentAmount,
                        copaymentFrecuency.Name);

                    var mailMessage = new MailMessage
                    {
                        Body = body,
                        Subject = "Nuevo servicio asignado – ADOM",
                        To = new MailAccount(professional.FirstName, professional.Email)
                    };
                    _mailService.SendMail(mailMessage);
                }
            }
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

        public ServiceResult<string> DeleteObservation(int assignServiceObservationId)
        {
            var result = _repository.DeleteObservation(assignServiceObservationId);
            return new ServiceResult<string>
            {
                Success = true,
                Result = result
            };
        }
    }
}
