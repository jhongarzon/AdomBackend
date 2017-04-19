using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetServices(int pageNumber, int pageSize);
        IEnumerable<Service> GetServices();
        IEnumerable<Service> GetServicesByPlanEntityId(int planEntityId);
        Service GetServiceById(int ServiceId);
        Service GetServiceByName(string name);
        Service GetServiceByNameWithoutId(int ServiceId, string name);
        Service Insert(Service Service);
        Service Update(Service Service);
    }
}
