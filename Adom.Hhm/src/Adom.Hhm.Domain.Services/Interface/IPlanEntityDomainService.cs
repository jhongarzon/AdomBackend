using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IPlanEntityDomainService
    {
        ServiceResult<IEnumerable<PlanEntity>> GetPlanEntity(int entityId);
        ServiceResult<PlanEntity> GetPlanEntityById(int PlanEntityId);
        ServiceResult<PlanEntity> Insert(PlanEntity planEntity);
        ServiceResult<PlanEntity> Update(PlanEntity planEntity);
    }
}
