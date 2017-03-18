using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IPlanRateDomainService
    {
        ServiceResult<IEnumerable<PlanRate>> GetPlanRate(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<PlanRate>> GetPlanRate();
        ServiceResult<PlanRate> GetPlanRateById(int PlanRateId);
        ServiceResult<PlanRate> Insert(PlanRate PlanRate);
        ServiceResult<PlanRate> Update(PlanRate PlanRate);
    }
}
