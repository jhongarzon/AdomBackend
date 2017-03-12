using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class ServiceAppService : IServiceAppService
    {
        private readonly IServiceDomainService service;

        public ServiceAppService(IServiceDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<Service> GetServiceById(int ServiceId)
        {
            return this.service.GetServiceById(ServiceId);
        }

        public ServiceResult<IEnumerable<Service>> GetServices(int pageNumber, int pageSize)
        {
            return this.service.GetServices(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<Service>> GetServices()
        {
            return this.service.GetServices();
        }

        public ServiceResult<Service> Insert(Service Service)
        {
            return this.service.Insert(Service);
        }

        public ServiceResult<Service> Update(Service Service)
        {
            return this.service.Update(Service);
        }
    }
}
