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
    public class ProfessionalRepository : IProfessionalRepository
    {
        private readonly IDbConnection connection;

        public ProfessionalRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public Professional GetProfessionalByEmail(string email)
        {
            return connection.Query<Professional>(ProfessionalQuerys.GetByEmail, new { Email = email }).FirstOrDefault();
        }

        public Professional GetProfessionalByEmailWithoutId(int ProfessionalId, string email)
        {
            return connection.Query<Professional>(ProfessionalQuerys.GetByEmailWithoutId, new { Email = email, ProfessionalId = ProfessionalId }).FirstOrDefault();
        }

        public Professional GetProfessionalById(int ProfessionalId)
        {
            return connection.Query<Professional>(ProfessionalQuerys.GetById, new { ProfessionalId = ProfessionalId }).FirstOrDefault();
        }

        public IEnumerable<Professional> GetProfessionals(int pageNumber, int pageSize)
        {
            return connection.Query<Professional>(ProfessionalQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<Professional> GetProfessionals()
        {
            return connection.Query<Professional>(ProfessionalQuerys.GetAllWithoutPagination);
        }

        public Professional Insert(Professional Professional)
        {
            var id = connection.Query<int>(ProfessionalQuerys.Insert, Professional).Single();
            Professional.ProfessionalId = id;
            Professional.State = true;
            return Professional;
        }

        public Professional Update(Professional Professional)
        {
            var affectedRows = connection.Execute(ProfessionalQuerys.Update, Professional);
            return Professional;
        }

        public Professional GetByDocument(int documentType, string document)
        {
            return connection.Query<Professional>(ProfessionalQuerys.GetByDocument, new { DocumentTypeId = documentType, Document = document }).FirstOrDefault();
        }
    }
}
