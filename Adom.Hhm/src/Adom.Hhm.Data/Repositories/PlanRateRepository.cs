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
    public class PlanRateRepository : IPlanRateRepository
    {
        private readonly IDbConnection connection;

        public PlanRateRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public PlanRate GetPlanRateByName(string name)
        {
            return connection.Query<PlanRate>(PlanRateQuerys.GetByName, new { Name = name }).FirstOrDefault();
        }

        public PlanRate GetPlanRateByNameWithoutId(int PlanRateId, string name)
        {
            return connection.Query<PlanRate>(PlanRateQuerys.GetByNameWithoutId, new { Name = name, PlanRateId = PlanRateId }).FirstOrDefault();
        }

        public PlanRate GetPlanRateById(int PlanRateId)
        {
            return connection.Query<PlanRate>(PlanRateQuerys.GetById, new { PlanRateId = PlanRateId }).FirstOrDefault();
        }

        public IEnumerable<PlanRate> GetPlanRate(int pageNumber, int pageSize)
        {
            return connection.Query<PlanRate>(PlanRateQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<PlanRate> GetPlanRate()
        {
            return connection.Query<PlanRate>(PlanRateQuerys.GetAllWithoutPagination);
        }

        public PlanRate Insert(PlanRate planRate)
        {
            var id = connection.Query<int>(PlanRateQuerys.Insert, planRate).Single();
            planRate.PlanRateId = id;
            return planRate;
        }

        public PlanRate Update(PlanRate planRate)
        {
            var affectedRows = connection.Execute(PlanRateQuerys.Update, planRate);
            return planRate;
        }
    }
}
