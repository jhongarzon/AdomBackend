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
    public class ServiceRepository : IServiceRepository
    {
        private readonly IDbConnection connection;

        public ServiceRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public Service GetServiceByName(string name)
        {
            return connection.Query<Service>(ServiceQuerys.GetByName, new { Name = name }).FirstOrDefault();
        }

        public Service GetServiceByNameWithoutId(int ServiceId, string name)
        {
            return connection.Query<Service>(ServiceQuerys.GetByNameWithoutId, new { Name = name, ServiceId = ServiceId }).FirstOrDefault();
        }

        public Service GetServiceById(int ServiceId)
        {
            return connection.Query<Service>(ServiceQuerys.GetById, new { ServiceId = ServiceId }).FirstOrDefault();
        }

        public IEnumerable<Service> GetServices(int pageNumber, int pageSize)
        {
            return connection.Query<Service>(ServiceQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<Service> GetServices()
        {
            return connection.Query<Service>(ServiceQuerys.GetAllWithoutPagination);
        }

        public Service Insert(Service Service)
        {
            var id = connection.Query<int>(ServiceQuerys.Insert, Service).Single();
            Service.ServiceId = id;
            return Service;
        }

        public Service Update(Service Service)
        {
            var affectedRows = connection.Execute(ServiceQuerys.Update, Service);
            return Service;
        }

        public IEnumerable<Service> GetServicesByPlanEntityId(int planEntityId)
        {
            return connection.Query<Service>(ServiceQuerys.GetByPlanEntityId, new { PlanEntityId = planEntityId });
        }
    }
}
