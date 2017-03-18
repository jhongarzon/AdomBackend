using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IServiceFrecuencyRepository
    {
        IEnumerable<ServiceFrecuency> GetServiceFrecuency(int pageNumber, int pageSize);
        IEnumerable<ServiceFrecuency> GetServiceFrecuency();
        ServiceFrecuency GetServiceFrecuencyById(int serviceFrecuencyId);
        ServiceFrecuency GetServiceFrecuencyByName(string name);
        ServiceFrecuency GetServiceFrecuencyByNameWithoutId(int serviceFrecuencyId, string name);
        ServiceFrecuency Insert(ServiceFrecuency serviceFrecuency);
        ServiceFrecuency Update(ServiceFrecuency serviceFrecuency);
    }
}
