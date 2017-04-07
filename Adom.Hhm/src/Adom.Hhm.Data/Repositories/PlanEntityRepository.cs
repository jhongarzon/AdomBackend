using System.Collections.Generic;
using System.Linq;
using System.Data;
using Adom.Hhm.Data.Querys;
using Dapper;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Entities;
using System;

namespace Adom.Hhm.Data.Repositories
{
    public class PlanEntityRepository : IPlanEntityRepository
    {
        private readonly IDbConnection connection;

        public PlanEntityRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public PlanEntity GetPlanEntityByName(string name, int entityId)
        {
            return connection.Query<PlanEntity>(PlanEntityQuerys.GetByName, new { Name = name, EntityId = entityId }).FirstOrDefault();
        }

        public PlanEntity GetPlanEntityByNameWithoutId(PlanEntity PlanEntity)
        {
            return connection.Query<PlanEntity>(PlanEntityQuerys.GetByNameWithoutId, PlanEntity).FirstOrDefault();
        }

        public PlanEntity GetPlanEntityById(int entityId)
        {
            return connection.Query<PlanEntity>(PlanEntityQuerys.GetById, new { EntityId = entityId }).FirstOrDefault();
        }

        public PlanEntity Insert(PlanEntity planEntity)
        {
            var id = connection.Query<int>(PlanEntityQuerys.Insert, planEntity).Single();
            planEntity.PlanEntityId = id;
            planEntity.State = true;
            return planEntity;
        }

        public PlanEntity Update(PlanEntity planEntity)
        {
            var affectedRows = connection.Execute(PlanEntityQuerys.Update, planEntity);
            return planEntity;
        }

        public IEnumerable<PlanEntity> GetPlanEntity(int entityId)
        {
            return connection.Query<PlanEntity>(PlanEntityQuerys.GetAllWithoutPagination, new { EntityId = entityId });
        }
    }
}
