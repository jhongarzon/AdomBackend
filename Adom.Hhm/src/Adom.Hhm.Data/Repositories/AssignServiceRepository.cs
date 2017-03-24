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
    public class AssignServiceRepository : IAssignServiceRepository
    {
        private readonly IDbConnection connection;

        public AssignServiceRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public AssignService GetAssignServiceByPatientId(int patientId)
        {
            return connection.Query<AssignService>(AssignServiceQuerys.GetByPateintId, new { @PatientId = patientId }).FirstOrDefault();
        }

        public AssignService GetAssignServiceById(int AssignServiceId)
        {
            return connection.Query<AssignService>(AssignServiceQuerys.GetById, new { AssignServiceId = AssignServiceId }).FirstOrDefault();
        }

        public IEnumerable<AssignService> GetAssignServices(int pageNumber, int pageSize)
        {
            return connection.Query<AssignService>(AssignServiceQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<AssignService> GetAssignServices()
        {
            return connection.Query<AssignService>(AssignServiceQuerys.GetAllWithoutPagination);
        }

        public AssignService Insert(AssignService assignService)
        {
            var id = connection.Query<int>(AssignServiceQuerys.CreateAssignServiceAndDetails, assignService, commandType: CommandType.StoredProcedure).Single();
            assignService.AssignServiceId = id;
            return assignService;
        }

        public AssignService Update(AssignService assignService)
        {
            var affectedRows = connection.Execute(AssignServiceQuerys.Update, assignService);
            return assignService;
        }
    }
}
