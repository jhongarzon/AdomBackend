using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class ServiceFrecuencyAppService : IServiceFrecuencyAppService
    {
        private readonly IServiceFrecuencyDomainService service;

        public ServiceFrecuencyAppService(IServiceFrecuencyDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<ServiceFrecuency> GetServiceFrecuencyById(int ServiceFrecuencyId)
        {
            return this.service.GetServiceFrecuencyById(ServiceFrecuencyId);
        }

        public ServiceResult<IEnumerable<ServiceFrecuency>> GetServiceFrecuency(int pageNumber, int pageSize)
        {
            return this.service.GetServiceFrecuency(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<ServiceFrecuency>> GetServiceFrecuency()
        {
            return this.service.GetServiceFrecuency();
        }

        public ServiceResult<ServiceFrecuency> Insert(ServiceFrecuency ServiceFrecuency)
        {
            return this.service.Insert(ServiceFrecuency);
        }

        public ServiceResult<ServiceFrecuency> Update(ServiceFrecuency ServiceFrecuency)
        {
            return this.service.Update(ServiceFrecuency);
        }
    }
}
