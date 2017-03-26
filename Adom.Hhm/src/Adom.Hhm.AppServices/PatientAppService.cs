using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class PatientAppService : IPatientAppService
    {
        private readonly IPatientDomainService service;

        public PatientAppService(IPatientDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<Patient> GetPatientById(int patientId)
        {
            return this.service.GetPatientById(patientId);
        }

        public ServiceResult<IEnumerable<Patient>> GetPatients(int pageNumber, int pageSize)
        {
            return this.service.GetPatients(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<Patient>> GetByNamesOrDocument(string dataFind)
        {
            return this.service.GetByNamesOrDocument(dataFind);
        }

        public ServiceResult<IEnumerable<Patient>> GetPatients()
        {
            return this.service.GetPatients();
        }

        public ServiceResult<Patient> Insert(Patient patient)
        {
            return this.service.Insert(patient);
        }

        public ServiceResult<Patient> Update(Patient patient)
        {
            return this.service.Update(patient);
        }
    }
}
