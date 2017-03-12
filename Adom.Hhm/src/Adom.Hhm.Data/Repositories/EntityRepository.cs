using Adom.Hhm.Data.Repositories;
using Adom.Hhm.Domain.Secutiry.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Data;
using Adom.Hhm.Data.Querys;
using Dapper;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;

namespace Adom.Hhm.Data.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly IDbConnection connection;

        public EntityRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public Entity GetEntityByName(string name)
        {
            return connection.Query<Entity>(EntityQuerys.GetByName, new { Name = name }).FirstOrDefault();
        }

        public Entity GetEntityByNameWithoutId(int entityId, string name)
        {
            return connection.Query<Entity>(EntityQuerys.GetByNameWithoutId, new { Name = name, EntityId = entityId }).FirstOrDefault();
        }

        public Entity GetEntityById(int entityId)
        {
            return connection.Query<Entity>(EntityQuerys.GetById, new { EntityId = entityId }).FirstOrDefault();
        }

        public IEnumerable<Entity> GetEntities(int pageNumber, int pageSize)
        {
            return connection.Query<Entity>(EntityQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<Entity> GetEntities()
        {
            return connection.Query<Entity>(EntityQuerys.GetAllWithoutPagination);
        }

        public Entity Insert(Entity entity)
        {
            var id = connection.Query<int>(EntityQuerys.Insert, entity).Single();
            entity.EntityId = id;
            return entity;
        }

        public Entity Update(Entity entity)
        {
            var affectedRows = connection.Execute(EntityQuerys.Update, entity);
            return entity;
        }
    }
}
