using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.AppServices.Interfaces
{
    public interface IPlanRateAppService
    {
        ServiceResult<IEnumerable<PlanRate>> GetPlanRate(int entityId);
        ServiceResult<PlanRate> GetPlanRateById(int PlanRateId);
        ServiceResult<PlanRate> Insert(PlanRate PlanRate);
        ServiceResult<PlanRate> Update(PlanRate PlanRate);
    }
}
