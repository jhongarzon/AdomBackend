using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Microsoft.Extensions.Configuration;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Utility;

namespace Adom.Hhm.Domain.Services
{
    public class PlanRateDomainServices : IPlanRateDomainService
    {
        private readonly IPlanRateRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public PlanRateDomainServices(IConfigurationRoot configuration, IPlanRateRepository repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        public ServiceResult<PlanRate> GetPlanRateById(int PlanRateId)
        {
            var getPlanRate = this.repository.GetPlanRateById(PlanRateId);

            return new ServiceResult<PlanRate>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPlanRate
            };
        }
        public ServiceResult<IEnumerable<PlanRate>> GetPlanRate(int entityId)
        {
            var getPlanRates = this.repository.GetPlanRate(entityId);
            return new ServiceResult<IEnumerable<PlanRate>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPlanRates
            };
        }

        public ServiceResult<PlanRate> Insert(PlanRate planRate)
        {
            var PlanRateInserted = this.repository.Insert(planRate);
            return new ServiceResult<PlanRate>
            {
                Success = true,
                Result = PlanRateInserted
            };
        }

        public ServiceResult<PlanRate> Update(PlanRate planRate)
        {
            var updated = this.repository.Update(planRate);
            return new ServiceResult<PlanRate>
            {
                Success = true,
                Result = updated
            };
        }
    }
}
