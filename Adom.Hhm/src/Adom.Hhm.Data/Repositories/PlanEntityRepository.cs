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

        public PlanEntity GetPlanEntityByName(string name)
        {
            return connection.Query<PlanEntity>(PlanEntityQuerys.GetByName, new { Name = name }).FirstOrDefault();
        }

        public PlanEntity GetPlanEntityByNameWithoutId(int planEntityId, string name)
        {
            return connection.Query<PlanEntity>(PlanEntityQuerys.GetByNameWithoutId, new { Name = name, PlanEntityId = planEntityId }).FirstOrDefault();
        }

        public PlanEntity GetPlanEntityById(int planEntityId)
        {
            return connection.Query<PlanEntity>(PlanEntityQuerys.GetById, new { PlanEntityId = planEntityId }).FirstOrDefault();
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
