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
    public class AssignServiceDetailRepository : IAssignServiceDetailRepository
    {
        private readonly IDbConnection connection;

        public AssignServiceDetailRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<AssignServiceDetail> GetAssignServiceDetailByAssignServiceId(int assignServiceId)
        {
            return connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetByAssignServiceId, new { AssignServiceId = assignServiceId });
        }

        public AssignServiceDetail GetAssignServiceDetailById(int assignServiceDetailId)
        {
            return connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetById, new { AssignServiceDetailId = assignServiceDetailId }).FirstOrDefault();
        }

        public IEnumerable<AssignServiceDetail> GetAssignServiceDetails(int pageNumber, int pageSize)
        {
            return connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<AssignServiceDetail> GetAssignServiceDetails()
        {
            return connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetAllWithoutPagination);
        }

        public AssignServiceDetail Update(AssignServiceDetail assignServiceDetail)
        {
            var id = connection.Query<int>(AssignServiceDetailQuerys.Update, new { AssignServiceId = assignServiceDetail.AssignServiceId, ProfessionalId = assignServiceDetail.ProfessionalId, DateVisit = assignServiceDetail.DateVisit, Consecutive = assignServiceDetail.Consecutive, StateId = assignServiceDetail.StateId } , commandType: CommandType.StoredProcedure).Single();
            assignServiceDetail.AssignServiceDetailId = id;
            return assignServiceDetail;
        }
    }
}
