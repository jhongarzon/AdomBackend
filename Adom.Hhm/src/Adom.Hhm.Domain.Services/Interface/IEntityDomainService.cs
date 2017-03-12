using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IEntityDomainService
    {
        ServiceResult<IEnumerable<Entity>> GetEntities(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<Entity>> GetEntities();
        ServiceResult<Entity> GetEntityById(int EntityId);
        ServiceResult<Entity> Insert(Entity Entity);
        ServiceResult<Entity> Update(Entity Entity);
    }
}
