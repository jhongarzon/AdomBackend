using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetPatients(int pageNumber, int pageSize);
        IEnumerable<Patient> GetPatients();
        Patient GetPatientById(int patientId);
        Patient GetPatientByEmail(string email);
        Patient GetPatientByEmailWithoutId(int patientId, string email);
        Patient GetPatientByDocument(string email);
        IEnumerable<Patient> GetByDocument(int documentTypeId, string dataFind);
        IEnumerable<Patient> GetByNames(string dataFind);
        Patient GetPatientByDocumentWithoutId(int patientId, string email);
        Patient Insert(Patient patient);
        Patient Update(Patient patient);
    }
}
