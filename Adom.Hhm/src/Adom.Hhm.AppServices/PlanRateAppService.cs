using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class PlanRateAppService : IPlanRateAppService
    {
        private readonly IPlanRateDomainService service;

        public PlanRateAppService(IPlanRateDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<PlanRate> GetPlanRateById(int PlanRateId)
        {
            return this.service.GetPlanRateById(PlanRateId);
        }

        public ServiceResult<IEnumerable<PlanRate>> GetPlanRate(int entityId)
        {
            return this.service.GetPlanRate(entityId);
        }

        public ServiceResult<PlanRate> Insert(PlanRate planRate)
        {
            return this.service.Insert(planRate);
        }

        public ServiceResult<bool> Delete(PlanRate planRate)
        {
            return this.service.Delete(planRate);
        }
    }
}
