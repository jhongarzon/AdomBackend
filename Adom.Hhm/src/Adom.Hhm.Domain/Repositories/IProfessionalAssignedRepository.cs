using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IProfessionalAssignedRepository
    {
        IEnumerable<ProfessionalAssignedServices> GetAssignedServices(int userId, int statusId);
    }
}
