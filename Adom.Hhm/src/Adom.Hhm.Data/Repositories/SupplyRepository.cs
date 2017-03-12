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
    public class SupplyRepository : ISupplyRepository
    {
        private readonly IDbConnection connection;

        public SupplyRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public Supply GetSupplyByName(string name)
        {
            return connection.Query<Supply>(SupplyQuerys.GetByName, new { Name = name }).FirstOrDefault();
        }

        public Supply GetSupplyByNameWithoutId(int supplyId, string name)
        {
            return connection.Query<Supply>(SupplyQuerys.GetByNameWithoutId, new { Name = name, SupplyId = supplyId }).FirstOrDefault();
        }

        public Supply GetSupplyById(int supplyId)
        {
            return connection.Query<Supply>(SupplyQuerys.GetById, new { SupplyId = supplyId }).FirstOrDefault();
        }

        public IEnumerable<Supply> GetSupplies(int pageNumber, int pageSize)
        {
            return connection.Query<Supply>(SupplyQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<Supply> GetSupplies()
        {
            return connection.Query<Supply>(SupplyQuerys.GetAllWithoutPagination);
        }

        public Supply Insert(Supply supply)
        {
            var id = connection.Query<int>(SupplyQuerys.Insert, supply).Single();
            supply.SupplyId = id;
            return supply;
        }

        public Supply Update(Supply supply)
        {
            var affectedRows = connection.Execute(SupplyQuerys.Update, supply);
            return supply;
        }
    }
}
