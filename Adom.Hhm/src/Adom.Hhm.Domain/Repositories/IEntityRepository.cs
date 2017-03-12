using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IEntityRepository
    {
        IEnumerable<Entity> GetEntities(int pageNumber, int pageSize);
        IEnumerable<Entity> GetEntities();
        Entity GetEntityById(int entityId);
        Entity GetEntityByName(string name);
        Entity GetEntityByNameWithoutId(int entityId, string name);
        Entity Insert(Entity entity);
        Entity Update(Entity entity);
    }
}
