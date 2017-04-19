using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IServiceDomainService
    {
        ServiceResult<IEnumerable<Service>> GetServices(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<Service>> GetServices();
        ServiceResult<IEnumerable<Service>> GetServicesByPlanEntityId(int planEntityId);
        ServiceResult<Service> GetServiceById(int ServiceId);
        ServiceResult<Service> Insert(Service Service);
        ServiceResult<Service> Update(Service Service);
    }
}
