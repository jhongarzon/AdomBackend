using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetPatients(int pageNumber, int pageSize);
        IEnumerable<Patient> GetPatients();
        Patient GetPatientById(int PatientId);
        Patient GetPatientByEmail(string email);
        Patient GetPatientByEmailWithoutId(int PatientId, string email);
        Patient GetPatientByDocument(string email);
        Patient GetPatientByDocumentWithoutId(int PatientId, string email);
        Patient Insert(Patient Patient);
        Patient Update(Patient Patient);
    }
}
