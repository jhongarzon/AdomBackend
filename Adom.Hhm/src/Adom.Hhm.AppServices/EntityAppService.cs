using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class EntityAppService : IEntityAppService
    {
        private readonly IEntityDomainService service;

        public EntityAppService(IEntityDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<Entity> GetEntityById(int entityId)
        {
            return this.service.GetEntityById(entityId);
        }

        public ServiceResult<IEnumerable<Entity>> GetEntities(int pageNumber, int pageSize)
        {
            return this.service.GetEntities(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<Entity>> GetEntities()
        {
            return this.service.GetEntities();
        }

        public ServiceResult<Entity> Insert(Entity entity)
        {
            return this.service.Insert(entity);
        }

        public ServiceResult<Entity> Update(Entity entity)
        {
            return this.service.Update(entity);
        }
    }
}
