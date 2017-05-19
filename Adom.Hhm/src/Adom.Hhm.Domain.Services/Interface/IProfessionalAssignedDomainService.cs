using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IProfessionalAssignedDomainService
    {
        ServiceResult<IEnumerable<ProfessionalAssignedServices>> GetAssignedServices(int userId, int statusId);
    }
}
