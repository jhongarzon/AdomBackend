using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.AppServices.Interfaces
{
    public interface ICoordinatorAppService
    {
        ServiceResult<IEnumerable<Coordinator>> GetCoordinators(int pageNumber, int pageSize);
        ServiceResult<Coordinator> GetCoordinatorById(int coordinatorId);
        ServiceResult<Coordinator> Insert(Coordinator coordinator);
        ServiceResult<Coordinator> Update(Coordinator coordinator);
    }
}
