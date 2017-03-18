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
    public class ServiceFrecuencyRepository : IServiceFrecuencyRepository
    {
        private readonly IDbConnection connection;

        public ServiceFrecuencyRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public ServiceFrecuency GetServiceFrecuencyByName(string name)
        {
            return connection.Query<ServiceFrecuency>(ServiceFrecuencyQuerys.GetByName, new { Name = name }).FirstOrDefault();
        }

        public ServiceFrecuency GetServiceFrecuencyByNameWithoutId(int ServiceFrecuencyId, string name)
        {
            return connection.Query<ServiceFrecuency>(ServiceFrecuencyQuerys.GetByNameWithoutId, new { Name = name, ServiceFrecuencyId = ServiceFrecuencyId }).FirstOrDefault();
        }

        public ServiceFrecuency GetServiceFrecuencyById(int ServiceFrecuencyId)
        {
            return connection.Query<ServiceFrecuency>(ServiceFrecuencyQuerys.GetById, new { ServiceFrecuencyId = ServiceFrecuencyId }).FirstOrDefault();
        }

        public IEnumerable<ServiceFrecuency> GetServiceFrecuency(int pageNumber, int pageSize)
        {
            return connection.Query<ServiceFrecuency>(ServiceFrecuencyQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<ServiceFrecuency> GetServiceFrecuency()
        {
            return connection.Query<ServiceFrecuency>(ServiceFrecuencyQuerys.GetAllWithoutPagination);
        }

        public ServiceFrecuency Insert(ServiceFrecuency ServiceFrecuency)
        {
            var id = connection.Query<int>(ServiceFrecuencyQuerys.Insert, ServiceFrecuency).Single();
            ServiceFrecuency.ServiceFrecuencyId = id;
            return ServiceFrecuency;
        }

        public ServiceFrecuency Update(ServiceFrecuency ServiceFrecuency)
        {
            var affectedRows = connection.Execute(ServiceFrecuencyQuerys.Update, ServiceFrecuency);
            return ServiceFrecuency;
        }
    }
}
