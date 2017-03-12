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
    public class EntityDomainServices : IEntityDomainService
    {
        private readonly IEntityRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public EntityDomainServices(IConfigurationRoot configuration, IEntityRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public ServiceResult<Entity> GetEntityById(int entityId)
        {
            var getEntity = this.repository.GetEntityById(entityId);

            return new ServiceResult<Entity>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getEntity
            };
        }

        public ServiceResult<IEnumerable<Entity>> GetEntities(int pageNumber, int pageSize)
        {
            var getEntitys = this.repository.GetEntities(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<Entity>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getEntitys
            };
        }

        public ServiceResult<IEnumerable<Entity>> GetEntities()
        {
            var getEntitys = this.repository.GetEntities();
            return new ServiceResult<IEnumerable<Entity>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getEntitys
            };
        }

        public ServiceResult<Entity> Insert(Entity entity)
        {
            Entity entityExist = this.repository.GetEntityByName(entity.Name);

            if (entityExist == null)
            {
                var EntityInserted = this.repository.Insert(entity);
                return new ServiceResult<Entity>
                {
                    Success = true,
                    Result = EntityInserted
                };
            }

            return new ServiceResult<Entity>
            {
                Success = false,
                Errors = new string[] { MessageError.NameEntityExists }
            };
        }

        public ServiceResult<Entity> Update(Entity entity)
        {
            Entity entityExist = this.repository.GetEntityByNameWithoutId(entity.EntityId, entity.Name);

            if (entityExist == null)
            {
                var updated = this.repository.Update(entity);
                return new ServiceResult<Entity>
                {
                    Success = true,
                    Result = updated
                };
            }

            return new ServiceResult<Entity>
            {
                Success = false,
                Errors = new string[] { MessageError.NameEntityExists }
            };
        }
    }
}
