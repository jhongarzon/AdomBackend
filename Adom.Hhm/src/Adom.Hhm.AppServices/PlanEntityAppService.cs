using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class PlanEntityAppService : IPlanEntityAppService
    {
        private readonly IPlanEntityDomainService service;

        public PlanEntityAppService(IPlanEntityDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<PlanEntity> GetPlanEntityById(int PlanEntityId)
        {
            return this.service.GetPlanEntityById(PlanEntityId);
        }

        public ServiceResult<IEnumerable<PlanEntity>> GetPlanEntity(int entityId)
        {
            return this.service.GetPlanEntity(entityId);
        }

        public ServiceResult<PlanEntity> Insert(PlanEntity planEntity)
        {
            return this.service.Insert(planEntity);
        }

        public ServiceResult<PlanEntity> Update(PlanEntity planEntity)
        {
            return this.service.Update(planEntity);
        }
    }
}
