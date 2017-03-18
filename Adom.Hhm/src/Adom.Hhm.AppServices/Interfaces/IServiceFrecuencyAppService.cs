using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.AppServices.Interfaces
{
    public interface IServiceFrecuencyAppService
    {
        ServiceResult<IEnumerable<ServiceFrecuency>> GetServiceFrecuency(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<ServiceFrecuency>> GetServiceFrecuency();
        ServiceResult<ServiceFrecuency> GetServiceFrecuencyById(int ServiceFrecuencyId);
        ServiceResult<ServiceFrecuency> Insert(ServiceFrecuency ServiceFrecuency);
        ServiceResult<ServiceFrecuency> Update(ServiceFrecuency ServiceFrecuency);
    }
}
