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

        public ServiceResult<IEnumerable<PlanRate>> GetPlanRate(int pageNumber, int pageSize)
        {
            var getPlanRates = this.repository.GetPlanRate(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<PlanRate>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPlanRates
            };
        }

        public ServiceResult<IEnumerable<PlanRate>> GetPlanRate()
        {
            var getPlanRates = this.repository.GetPlanRate();
            return new ServiceResult<IEnumerable<PlanRate>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPlanRates
            };
        }

        public ServiceResult<PlanRate> Insert(PlanRate planRate)
        {
            PlanRate PlanRateExist = this.repository.GetPlanRateByName(planRate.PlanName);

            if (PlanRateExist == null)
            {
                var PlanRateInserted = this.repository.Insert(planRate);
                return new ServiceResult<PlanRate>
                {
                    Success = true,
                    Result = PlanRateInserted
                };
            }

            return new ServiceResult<PlanRate>
            {
                Success = false,
                Errors = new string[] { MessageError.NamePlanRateExists }
            };
        }

        public ServiceResult<PlanRate> Update(PlanRate planRate)
        {
            PlanRate PlanRateExist = this.repository.GetPlanRateByNameWithoutId(planRate.PlanRateId, planRate.PlanName);

            if (PlanRateExist == null)
            {
                var updated = this.repository.Update(planRate);
                return new ServiceResult<PlanRate>
                {
                    Success = true,
                    Result = updated
                };
            }

            return new ServiceResult<PlanRate>
            {
                Success = false,
                Errors = new string[] { MessageError.NamePlanRateExists }
            };
        }
    }
}
