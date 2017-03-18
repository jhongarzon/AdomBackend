using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IPlanRateRepository
    {
        IEnumerable<PlanRate> GetPlanRate(int pageNumber, int pageSize);
        IEnumerable<PlanRate> GetPlanRate();
        PlanRate GetPlanRateById(int planRateId);
        PlanRate GetPlanRateByName(string name);
        PlanRate GetPlanRateByNameWithoutId(int planRateId, string name);
        PlanRate Insert(PlanRate planRate);
        PlanRate Update(PlanRate planRate);
    }
}
