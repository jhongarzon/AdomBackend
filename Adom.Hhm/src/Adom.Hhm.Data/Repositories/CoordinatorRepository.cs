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
    public class CoordinatorRepository : ICoordinatorRepository
    {
        private readonly IDbConnection connection;

        public CoordinatorRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public Coordinator GetCoordinatorByEmail(string email)
        {
            return connection.Query<Coordinator>(CoordinatorQuerys.GetByEmail, new { Email = email }).FirstOrDefault();
        }

        public Coordinator GetCoordinatorByEmailWithoutId(int coordinatorId, string email)
        {
            return connection.Query<Coordinator>(CoordinatorQuerys.GetByEmailWithoutId, new { Email = email, CoordinatorId = coordinatorId }).FirstOrDefault();
        }

        public Coordinator GetCoordinatorById(int coordinatorId)
        {
            return connection.Query<Coordinator>(CoordinatorQuerys.GetById, new { CoordinatorId = coordinatorId }).FirstOrDefault();
        }

        public IEnumerable<Coordinator> GetCoordinators(int pageNumber, int pageSize)
        {
            return connection.Query<Coordinator>(CoordinatorQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<Coordinator> GetCoordinators()
        {
            return connection.Query<Coordinator>(CoordinatorQuerys.GetAllWithoutPagination);
        }

        public Coordinator Insert(Coordinator coordinator)
        {
            var id = connection.Query<int>(CoordinatorQuerys.Insert, coordinator).Single();
            coordinator.CoordinatorId = id;
            coordinator.State = true;
            return coordinator;
        }

        public Coordinator Update(Coordinator coordinator)
        {
            var affectedRows = connection.Execute(CoordinatorQuerys.Update, coordinator);
            return coordinator;
        }
    }
}
