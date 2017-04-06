using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IPlanEntityRepository
    {
        IEnumerable<PlanEntity> GetPlanEntity(int entityId);
        PlanEntity GetPlanEntityById(int planEntityId);
        PlanEntity GetPlanEntityByName(string name);
        PlanEntity GetPlanEntityByNameWithoutId(int PlanEntityId, string name);
        PlanEntity Insert(PlanEntity PlanEntity);
        PlanEntity Update(PlanEntity PlanEntity);
    }
}
