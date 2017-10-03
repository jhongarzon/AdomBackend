using System.Collections.Generic;
using System.Linq;
using Adom.Hhm.Domain.Entities.Security;
using Microsoft.Extensions.Configuration;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Utility;

namespace Adom.Hhm.Domain.Services
{
    public class PatientDomainServices : IPatientDomainService
    {
        private readonly IPatientRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public PatientDomainServices(IConfigurationRoot configuration, IPatientRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public ServiceResult<Patient> GetPatientById(int PatientId)
        {
            var getPatient = repository.GetPatientById(PatientId);

            return new ServiceResult<Patient>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPatient
            };
        }

        public ServiceResult<IEnumerable<Patient>> GetPatients(int pageNumber, int pageSize)
        {
            var getPatients = repository.GetPatients(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<Patient>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPatients
            };
        }

        public ServiceResult<IEnumerable<Patient>> GetByDocument(int documentTypeId, string dataFind)
        {
            var getPatients = repository.GetByDocument(documentTypeId, dataFind);

            return new ServiceResult<IEnumerable<Patient>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPatients
            };
        }
        public ServiceResult<IEnumerable<Patient>> GetByNames(string dataFind)
        {
            var getPatients = repository.GetByNames(dataFind);

            return new ServiceResult<IEnumerable<Patient>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPatients
            };
        }

        public ServiceResult<IEnumerable<Patient>> GetPatients()
        {
            var getPatients = repository.GetPatients();
            return new ServiceResult<IEnumerable<Patient>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPatients
            };
        }

        public ServiceResult<Patient> Insert(Patient patient)
        {
            var emailExist = repository.GetPatientByEmail(patient.Email);
            var documentExist = repository.GetByDocument(patient.DocumentTypeId, patient.Document);

            if (documentExist != null && documentExist.Any())
                return new ServiceResult<Patient>
                {
                    Success = false,
                    Errors = new[] { MessageError.DocumentExists }
                };

            if (emailExist != null)
                return new ServiceResult<Patient>
                {
                    Success = false,
                    Errors = new[] { MessageError.EmailExists }
                };

            var patientInserted = repository.Insert(patient);
            return new ServiceResult<Patient>
            {
                Success = true,
                Result = patientInserted
            };
        }

        public ServiceResult<Patient> Update(Patient patient)
        {
            var emailExist = repository.GetPatientByEmailWithoutId(patient.PatientId, patient.Email);
            var documentExist = repository.GetPatientByDocumentWithoutId(patient.PatientId, patient.Document, patient.DocumentTypeId);

            if (documentExist == null)
            {
                if (emailExist == null)
                {
                    var updated = repository.Update(patient);
                    return new ServiceResult<Patient>
                    {
                        Success = true,
                        Result = updated
                    };
                }

                else
                {
                    return new ServiceResult<Patient>
                    {
                        Success = false,
                        Errors = new string[] { MessageError.EmailExists }
                    };
                }
            }
            else
            {
                return new ServiceResult<Patient>
                {
                    Success = false,
                    Errors = new string[] { MessageError.DocumentExists }
                };
            }
        }
    }
}
