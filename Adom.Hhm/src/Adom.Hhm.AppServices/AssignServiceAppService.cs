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
            return this.service.GetAssignServiceById(AssignServiceId);
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServiceByPatientId(int patientId)
        {
            return this.service.GetAssignServiceByPatientId(patientId);
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServices(int pageNumber, int pageSize)
        {
            return this.service.GetAssignServices(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServices()
        {
            return this.service.GetAssignServices();
        }

        public ServiceResult<AssignService> Insert(AssignService assignService)
        {
            return this.service.Insert(assignService);
        }

        public ServiceResult<AssignService> Update(AssignService assignService)
        {
            return this.service.Update(assignService);
        }

        public ServiceResult<string> CalculateFinalDateAssignService(int quantity, int serviceFrecuencyId, string initialDate)
        {
            return this.service.CalculateFinalDateAssignService(quantity, serviceFrecuencyId, initialDate);
        }
    }
}
