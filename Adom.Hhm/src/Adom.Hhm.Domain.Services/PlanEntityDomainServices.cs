using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Microsoft.Extensions.Configuration;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Utility;
using Adom.Hhm.Domain.Services.Interface;

namespace Adom.Hhm.Domain.Services
{
    public class PlanEntityDomainServices : IPlanEntityDomainService
    {
        private readonly IPlanEntityRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public PlanEntityDomainServices(IConfigurationRoot configuration, IPlanEntityRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public ServiceResult<PlanEntity> GetPlanEntityById(int planEntityId)
        {
            var getPlanEntity = this.repository.GetPlanEntityById(planEntityId);

            return new ServiceResult<PlanEntity>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPlanEntity
            };
        }

        public ServiceResult<IEnumerable<PlanEntity>> GetPlanEntity(int entityId)
        {
            var getPlanEntity = this.repository.GetPlanEntity(entityId);
            return new ServiceResult<IEnumerable<PlanEntity>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPlanEntity
            };
        }

        public ServiceResult<PlanEntity> Insert(PlanEntity planEntity)
        {
            PlanEntity planEntityExist = this.repository.GetPlanEntityByName(planEntity.Name);

            if (planEntityExist == null)
            {
                var planEntityInserted = this.repository.Insert(planEntity);

                return new ServiceResult<PlanEntity>
                {
                    Success = true,
                    Result = planEntityInserted
                };
            }

            return new ServiceResult<PlanEntity>
            {
                Success = false,
                Errors = new string[] { MessageError.NamePlanEntityExists }
            };
        }

        public ServiceResult<PlanEntity> Update(PlanEntity planEntity)
        {
            PlanEntity planEntityExist = this.repository.GetPlanEntityByNameWithoutId(planEntity.PlanEntityId, planEntity.Name);

            if (planEntityExist == null)
            {
                var updated = this.repository.Update(planEntity);
                return new ServiceResult<PlanEntity>
                {
                    Success = true,
                    Result = updated
                };
            }

            return new ServiceResult<PlanEntity>
            {
                Success = false,
                Errors = new string[] { MessageError.NamePlanEntityExists }
            };
        }
    }
}
