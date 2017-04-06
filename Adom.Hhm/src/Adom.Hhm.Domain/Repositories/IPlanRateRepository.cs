using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IPlanRateRepository
    {
        IEnumerable<PlanRate> GetPlanRate(int entityId);
        PlanRate GetPlanRateById(int planRateId);
        PlanRate Insert(PlanRate planRate);
        PlanRate Update(PlanRate planRate);
    }
}
