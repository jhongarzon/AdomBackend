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
    public class AssignServiceSupplyRepository : IAssignServiceSupplyRepository
    {
        private readonly IDbConnection connection;

        public AssignServiceSupplyRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public AssignServiceSupply GetAssignServiceSupplyById(int assignServiceSupplyId)
        {
            return connection.Query<AssignServiceSupply>(AssignServiceSupplyQuerys.GetById, new { AssignServiceSupplyId = assignServiceSupplyId }).FirstOrDefault();
        }

        public IEnumerable<AssignServiceSupply> GetAssignServiceSupplyByAssignServiceId(int assignServiceId)
        {
            return connection.Query<AssignServiceSupply>(AssignServiceSupplyQuerys.GetByAssignServiceId, new { AssignServiceId = assignServiceId });
        }

        public IEnumerable<AssignServiceSupply> GetAssignServiceSupplies(int pageNumber, int pageSize)
        {
            return connection.Query<AssignServiceSupply>(AssignServiceSupplyQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<AssignServiceSupply> GetAssignServiceSupplies()
        {
            return connection.Query<AssignServiceSupply>(AssignServiceSupplyQuerys.GetAllWithoutPagination);
        }

        public AssignServiceSupply Insert(AssignServiceSupply assignServiceSupply)
        {
            var id = connection.Query<int>(AssignServiceSupplyQuerys.Insert, assignServiceSupply).Single();
            assignServiceSupply.AssignServiceSupplyId = id;
            return assignServiceSupply;
        }

        public AssignServiceSupply Update(AssignServiceSupply assignServiceSupply)
        {
            var affectedRows = connection.Execute(AssignServiceSupplyQuerys.Update, assignServiceSupply);
            return assignServiceSupply;
        }

        public bool Delete(int assignServiceSupplyId)
        {
            var affectedRows = connection.Execute(AssignServiceSupplyQuerys.Delete, new { AssignServiceSupplyId = assignServiceSupplyId });
            return affectedRows > 0;
        }
    }
}
