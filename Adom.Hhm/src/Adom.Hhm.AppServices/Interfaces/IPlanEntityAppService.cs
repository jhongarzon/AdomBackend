using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.AppServices.Interfaces
{
    public interface IPlanEntityAppService
    {
        ServiceResult<IEnumerable<PlanEntity>> GetPlanEntity(int entityId);
        ServiceResult<PlanEntity> GetPlanEntityById(int planEntityId);
        ServiceResult<PlanEntity> Insert(PlanEntity planEntity);
        ServiceResult<PlanEntity> Update(PlanEntity planEntity);
    }
}
