using System.Collections.Generic;
using System.Linq;
using System.Data;
using Adom.Hhm.Data.Querys;
using Dapper;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;

namespace Adom.Hhm.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnection connection;

        public PatientRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public Patient GetPatientByDocument(string document)
        {
            return connection.Query<Patient>(PatientQuerys.GetByDocument, new { Document = document }).FirstOrDefault();
        }

        public Patient GetPatientByDocumentWithoutId(int PatientId, string document)
        {
            return connection.Query<Patient>(PatientQuerys.GetByDocumentWithoutId, new { Document = document, PatientId = PatientId }).FirstOrDefault();
        }

        public Patient GetPatientByEmail(string email)
        {
            return connection.Query<Patient>(PatientQuerys.GetByEmail, new { Email = email }).FirstOrDefault();
        }

        public Patient GetPatientByEmailWithoutId(int PatientId, string email)
        {
            return connection.Query<Patient>(PatientQuerys.GetByEmailWithoutId, new { Email = email, PatientId = PatientId }).FirstOrDefault();
        }

        public Patient GetPatientById(int PatientId)
        {
            return connection.Query<Patient>(PatientQuerys.GetById, new { PatientId = PatientId }).FirstOrDefault();
        }

        public IEnumerable<Patient> GetPatients(int pageNumber, int pageSize)
        {
            return connection.Query<Patient>(PatientQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public Patient Insert(Patient Patient)
        {
            var id = connection.Query<int>(PatientQuerys.Insert, Patient).Single();
            Patient.PatientId = id;
            Patient.State = true;
            return Patient;
        }

        public Patient Update(Patient Patient)
        {
            var affectedRows = connection.Execute(PatientQuerys.Update, Patient);
            return Patient;
        }
    }
}
