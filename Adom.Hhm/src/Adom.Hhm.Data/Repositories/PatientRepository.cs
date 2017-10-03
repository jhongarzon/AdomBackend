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

        public Patient GetPatientByDocumentWithoutId(int patientId, string document, int documentTypeId)
        {
            return connection.Query<Patient>(PatientQuerys.GetByDocumentWithoutId, new { Document = document, PatientId = patientId, DocumentTypeId = documentTypeId }).FirstOrDefault();
        }

        public Patient GetPatientByEmail(string email)
        {
            return connection.Query<Patient>(PatientQuerys.GetByEmail, new { Email = email }).FirstOrDefault();
        }

        public Patient GetPatientByEmailWithoutId(int patientId, string email)
        {
            return connection.Query<Patient>(PatientQuerys.GetByEmailWithoutId, new { Email = email, PatientId = patientId }).FirstOrDefault();
        }
        public IEnumerable<Patient> GetByDocument(int documentTypeId, string dataFind)
        {
            return connection.Query<Patient>(PatientQuerys.GetByDocumentType, new { DocumentTypeId = documentTypeId, DataFind = "%" + dataFind + "%" });
        }
        public IEnumerable<Patient> GetByNames(string dataFind)
        {
            return connection.Query<Patient>(PatientQuerys.GetByNamesOrDocument, new { DataFind = "%" + dataFind + "%" });
        }

        public Patient GetPatientById(int patientId)
        {
            return connection.Query<Patient>(PatientQuerys.GetById, new { PatientId = patientId }).FirstOrDefault();
        }

        public IEnumerable<Patient> GetPatients(int pageNumber, int pageSize)
        {
            return connection.Query<Patient>(PatientQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<Patient> GetPatients()
        {
            return connection.Query<Patient>(PatientQuerys.GetAllWithoutPagination);
        }

        public Patient Insert(Patient patient)
        {
            patient.NameCompleted = patient.FirstName + (patient.SecondName == null ? " " : " " + patient.SecondName + " ") + patient.Surname + (patient.SecondSurname == null ? "" : " " + patient.SecondSurname);
            var id = connection.Query<int>(PatientQuerys.Insert, patient).Single();
            patient.PatientId = id;
            return patient;
        }

        public Patient Update(Patient patient)
        {
            patient.NameCompleted = patient.FirstName + (patient.SecondName == null ? " " : " " + patient.SecondName + " ") + patient.Surname + (patient.SecondSurname == null ? "" : " " + patient.SecondSurname);
            var affectedRows = connection.Execute(PatientQuerys.Update, patient);
            return patient;
        }
    }
}
