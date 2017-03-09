using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.AppServices.Interfaces
{
    public interface IPatientAppService
    {
        ServiceResult<IEnumerable<Patient>> GetPatients(int pageNumber, int pageSize);
        ServiceResult<Patient> GetPatientById(int patientId);
        ServiceResult<Patient> Insert(Patient patient);
        ServiceResult<Patient> Update(Patient patient);
    }
}
