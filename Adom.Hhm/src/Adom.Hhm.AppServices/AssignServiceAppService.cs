using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;
using System;

namespace Adom.Hhm.AppServices
{
    public class AssignServiceAppService : IAssignServiceAppService
    {
        private readonly IAssignServiceDomainService service;

        public AssignServiceAppService(IAssignServiceDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<AssignService> GetAssignServiceById(int AssignServiceId)
        {
            return service.GetAssignServiceById(AssignServiceId);
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServiceByPatientId(int patientId)
        {
            return service.GetAssignServiceByPatientId(patientId);
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServices(int pageNumber, int pageSize)
        {
            return service.GetAssignServices(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServices()
        {
            return service.GetAssignServices();
        }

        public ServiceResult<AssignService> Insert(AssignService assignService)
        {
            return service.Insert(assignService);
        }

        public ServiceResult<IEnumerable<ServiceObservation>> GetServiceObservations(int assignServiceId,int userId)
        {
            return service.GetServiceObservations(assignServiceId, userId);
        }

        public ServiceResult<ServiceObservation> InsertObservation(ServiceObservation serviceObservation)
        {
            return service.InsertObservation(serviceObservation);
        }

        public ServiceResult<AssignService> Update(AssignService assignService)
        {
            return service.Update(assignService);
        }

        public ServiceResult<string> CalculateFinalDateAssignService(int quantity, int serviceFrecuencyId, string initialDate)
        {
            return service.CalculateFinalDateAssignService(quantity, serviceFrecuencyId, initialDate);
        }

        public ServiceResult<string> DeleteObservation(int assignServiceObservationId)
        {
            return service.DeleteObservation(assignServiceObservationId);
        }
    }
}
