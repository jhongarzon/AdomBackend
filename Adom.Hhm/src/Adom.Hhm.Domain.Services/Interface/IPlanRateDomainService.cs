using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IPlanRateDomainService
    {
        ServiceResult<IEnumerable<PlanRate>> GetPlanRate(int entityId);
        ServiceResult<PlanRate> GetPlanRateById(int PlanRateId);
        ServiceResult<PlanRate> Insert(PlanRate PlanRate);
        ServiceResult<bool> Delete(PlanRate PlanRate);
    }
}
