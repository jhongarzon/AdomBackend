using System.Collections.Generic;
using System.Linq;
using System.Data;
using Adom.Hhm.Data.Querys;
using Dapper;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;
using System;

namespace Adom.Hhm.Data.Repositories
{
    public class ParameterRepository : IParameterRepository
    {
        private readonly IDbConnection connection;

        public ParameterRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<Parameter> GetAccountType()
        {
            return connection.Query<Parameter>(ParameterQuerys.GetAccountType);
        }

        public IEnumerable<Parameter> GetClassification()
        {
            return connection.Query<Parameter>(ParameterQuerys.GetClassification);
        }

        public IEnumerable<Parameter> GetDocumentType()
        {
            return connection.Query<Parameter>(ParameterQuerys.GetDocumentType);
        }

        public IEnumerable<Parameter> GetGender()
        {
            return connection.Query<Parameter>(ParameterQuerys.GetGender);
        }

        public IEnumerable<Parameter> GetServiceType()
        {
            return connection.Query<Parameter>(ParameterQuerys.GetServiceType);
        }

        public IEnumerable<Parameter> GetSpecialties()
        {
            return connection.Query<Parameter>(ParameterQuerys.GetSpecialties);
        }

        public IEnumerable<Parameter> GetZones()
        {
            return connection.Query<Parameter>(ParameterQuerys.GetZones);
        }

        public IEnumerable<Parameter> GetUnitTime()
        {
            return connection.Query<Parameter>(ParameterQuerys.GetUnitTime);
        }
    }
}
