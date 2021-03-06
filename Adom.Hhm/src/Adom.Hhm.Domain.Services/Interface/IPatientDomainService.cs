﻿using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IPatientDomainService
    {
        ServiceResult<IEnumerable<Patient>> GetPatients(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<Patient>> GetPatients();
        ServiceResult<IEnumerable<Patient>> GetByNames(string dataFind);
        ServiceResult<IEnumerable<Patient>> GetByDocument(int documentTypeId, string dataFind);
        ServiceResult<Patient> GetPatientById(int patientId);
        ServiceResult<Patient> Insert(Patient patient);
        ServiceResult<Patient> Update(Patient patient);
    }
}
