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
    public class CoPaymentFrecuencyRepository : ICoPaymentFrecuencyRepository
    {
        private readonly IDbConnection connection;

        public CoPaymentFrecuencyRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public CoPaymentFrecuency GetCoPaymentFrecuencyByName(string name)
        {
            return connection.Query<CoPaymentFrecuency>(CoPaymentFrecuencyQuerys.GetByName, new { Name = name }).FirstOrDefault();
        }

        public CoPaymentFrecuency GetCoPaymentFrecuencyByNameWithoutId(int CoPaymentFrecuencyId, string name)
        {
            return connection.Query<CoPaymentFrecuency>(CoPaymentFrecuencyQuerys.GetByNameWithoutId, new { Name = name, CoPaymentFrecuencyId = CoPaymentFrecuencyId }).FirstOrDefault();
        }

        public CoPaymentFrecuency GetCoPaymentFrecuencyById(int CoPaymentFrecuencyId)
        {
            return connection.Query<CoPaymentFrecuency>(CoPaymentFrecuencyQuerys.GetById, new { CoPaymentFrecuencyId = CoPaymentFrecuencyId }).FirstOrDefault();
        }

        public IEnumerable<CoPaymentFrecuency> GetCoPaymentFrecuency(int pageNumber, int pageSize)
        {
            return connection.Query<CoPaymentFrecuency>(CoPaymentFrecuencyQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<CoPaymentFrecuency> GetCoPaymentFrecuency()
        {
            return connection.Query<CoPaymentFrecuency>(CoPaymentFrecuencyQuerys.GetAllWithoutPagination);
        }

        public CoPaymentFrecuency Insert(CoPaymentFrecuency CoPaymentFrecuency)
        {
            var id = connection.Query<int>(CoPaymentFrecuencyQuerys.Insert, CoPaymentFrecuency).Single();
            CoPaymentFrecuency.CoPaymentFrecuencyId = id;
            return CoPaymentFrecuency;
        }

        public CoPaymentFrecuency Update(CoPaymentFrecuency CoPaymentFrecuency)
        {
            var affectedRows = connection.Execute(CoPaymentFrecuencyQuerys.Update, CoPaymentFrecuency);
            return CoPaymentFrecuency;
        }
    }
}
